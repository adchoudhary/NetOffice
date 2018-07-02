#include "stdafx.h"
#include "DllRegister.h"

BOOL SetKeyAndValue(HKEY hKeyRoot, LPCWSTR pszPath, LPCWSTR pszSubkey, LPCWSTR pszValue)
{
	HKEY hKey;
	WCHAR szKeyBuf[1024];

	lstrcpy(szKeyBuf, pszPath);

	if (pszSubkey != NULL)
	{
		lstrcat(szKeyBuf, L"\\");
		lstrcat(szKeyBuf, pszSubkey);
	}

	// if its return 5 - E_ACCESS_DENIED
	long lResult = RegCreateKeyEx(hKeyRoot, szKeyBuf, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, NULL, &hKey, NULL);
	if (lResult != ERROR_SUCCESS)
		return FALSE;

	if (pszValue != NULL)
	{
		#if UNICODE
			RegSetValueEx(hKey, NULL, 0, REG_SZ, (BYTE*)pszValue, lstrlen(pszValue) * 2 + 2);
		#else
			RegSetValueEx(hKey, NULL, 0, REG_SZ, (BYTE*)pszValue, lstrlen(pszValue) + 1);
		#endif
	}

	RegCloseKey(hKey);
	return TRUE;
}

LONG RecursiveDeleteKey(HKEY hKeyParent, LPCWSTR pszKeyChild)
{
	HKEY hKeyChild;
	LONG lRes = RegOpenKeyEx(hKeyParent, pszKeyChild, 0, KEY_ALL_ACCESS, &hKeyChild);
	if (lRes != ERROR_SUCCESS)
		return lRes;

	FILETIME time;
	WCHAR szBuffer[256];
	DWORD dwSize = 256;
	while (RegEnumKeyEx(hKeyChild, 0, szBuffer, &dwSize, NULL, NULL, NULL, &time) == S_OK)
	{
		lRes = RecursiveDeleteKey(hKeyChild, szBuffer);
		if (lRes != ERROR_SUCCESS)
		{
			RegCloseKey(hKeyChild);
			return lRes;
		}
		dwSize = 256;
	}

	RegCloseKey(hKeyChild);
	return RegDeleteKey(hKeyParent, pszKeyChild);
}

HKEY RootKey(RegisterMode mode)
{
	HKEY hKeyRoot = HKEY_CURRENT_USER;
	switch (mode)
	{
	case System:
	case SystemComponentAndUserAddin:
		hKeyRoot = HKEY_CLASSES_ROOT;
		break;
	}
	return hKeyRoot;
}

void ClassIdKey(LPCWSTR classId,  RegisterMode mode, WCHAR* classIdKey)
{
	if (mode == User)
	{
		lstrcpy(classIdKey, L"Software\\Classes\\");
	}
	else
	{
		lstrcpy(classIdKey, L"");
	}
	lstrcat(classIdKey, L"CLSID\\");
	lstrcat(classIdKey, classId);
}

LPCWSTR ProgIdKey(LPCWSTR progId,  RegisterMode mode, WCHAR* progIdKey)
{
	if (mode == User)
	{
		lstrcpy(progIdKey, L"Software\\Classes\\");
	}
	else
	{
		lstrcpy(progIdKey, L"");
	}
	lstrcat(progIdKey, progId);
	return progIdKey;
}

HRESULT RegisterCOMAddin(LPCWSTR pszOfficeApp, LPCWSTR pszProgID, LPCWSTR pszFriendlyName, LPCWSTR pszDescription, DWORD dwStartupContext, DWORD dwCommandLineSafe, bool registerPerMachine)
{
	HRESULT hr = S_OK;
	WCHAR szKeyBuf[1024];
	DWORD dwTemp = 0;
	bool keyCreated = false;
	HKEY hKey;

	lstrcpy(szKeyBuf, L"Software\\Microsoft\\Office\\");
	lstrcat(szKeyBuf, pszOfficeApp);
	lstrcat(szKeyBuf, L"\\Addins\\");
	lstrcat(szKeyBuf, pszProgID);

	HKEY root = registerPerMachine ? HKEY_LOCAL_MACHINE : HKEY_CURRENT_USER;
	IfFailGo(RegCreateKeyEx(root, szKeyBuf, 0, NULL, REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, NULL, &hKey, NULL));

	IfFailGo(RegSetValueEx(hKey, L"LoadBehavior", 0, REG_DWORD, (BYTE*)&dwStartupContext, sizeof(DWORD)));
	IfFailGo(RegSetValueEx(hKey, L"CommandLineSafe", 0, REG_DWORD, (BYTE*)&dwCommandLineSafe, sizeof(DWORD)));

	if (NULL != pszFriendlyName)
	{
		#if UNICODE
			dwTemp = lstrlen(pszFriendlyName) * 2 + 2;
		#else
			dwTemp = lstrlen(pszFriendlyName) + 1;
		#endif
		IfFailGo(RegSetValueEx(hKey, L"FriendlyName", 0, REG_SZ, (BYTE*)pszFriendlyName, dwTemp));

		#if UNICODE
			dwTemp = lstrlen(pszDescription) * 2 + 2;
		#else
			dwTemp = lstrlen(pszDescription) + 1;
		#endif
		IfFailGo(RegSetValueEx(hKey, L"Description", 0, REG_SZ, (BYTE*)pszDescription, dwTemp));
	}

	RegCloseKey(hKey);

	return hr;
Error:
	if (keyCreated)
	{
		RegCloseKey(hKey);
		RegDeleteKey(hKey, szKeyBuf);
	}
	return hr;
}

HRESULT UnRegisterCOMAddin(LPCWSTR pszOfficeApp, LPCWSTR pszProgID)
{
	HRESULT result = S_OK;

	WCHAR szKeyBuf[1024];
	lstrcpy(szKeyBuf, L"Software\\Microsoft\\Office\\");
	lstrcat(szKeyBuf, pszOfficeApp);
	lstrcat(szKeyBuf, L"\\Addins\\");
	lstrcat(szKeyBuf, pszProgID);

	HRESULT hr = RecursiveDeleteKey(HKEY_CURRENT_USER, szKeyBuf);
	if (E_ACCESSDENIED != hr) // if key is missing - we dont care
	{
		result = hr;
	}

	return result;
}

HRESULT RegisterCOMComponent(HINSTANCE module, LPCWSTR officeApplication, LPCWSTR progId, LPCWSTR classId, LPCWSTR version, LPCWSTR description, RegisterMode mode)
{
	WCHAR szModule[512];
	DWORD dwResult = ::GetModuleFileName(module, szModule, 512);
	if (0 == dwResult)
		return E_FAIL;

	HKEY hKeyRoot = RootKey(mode);
	WCHAR classIdKey[512];
	ClassIdKey(classId, mode, classIdKey);
	WCHAR progIdKey[512];
	ProgIdKey(progId, mode, progIdKey);

	WCHAR inProcServer32[128];
	lstrcpy(inProcServer32, L"");
	lstrcat(inProcServer32, L"InprocServer32");
	//lstrcat(inProcServer32, version);
	// todo: version and programmable key

	if (!SetKeyAndValue(hKeyRoot, classIdKey, NULL, description))
		return S_FALSE;
	if (!SetKeyAndValue(hKeyRoot, classIdKey, inProcServer32, szModule))
		return S_FALSE;
	if (!SetKeyAndValue(hKeyRoot, classIdKey, L"ProgID", progId))
		return S_FALSE;
	if (!SetKeyAndValue(hKeyRoot, progIdKey, NULL, description))
		return S_FALSE;
	if (!SetKeyAndValue(hKeyRoot, progIdKey, L"CLSID", classId))
		return S_FALSE;

	return S_OK;
}

HRESULT UnregisterCOMComponent(LPCWSTR officeApplication, LPCWSTR progId, LPCWSTR classId, LPCWSTR version, RegisterMode mode)
{
	HRESULT result = S_OK;

	HKEY hKeyRoot = RootKey(mode);
	WCHAR classIdKey[512];
	ClassIdKey(classId, mode, classIdKey);
	WCHAR progIdKey[512];
	ProgIdKey(progId, mode, progIdKey);

	if (0 != RecursiveDeleteKey(hKeyRoot, classIdKey))
		result = E_FAIL;
	if (0 != RecursiveDeleteKey(hKeyRoot, progIdKey))
		result = E_FAIL;

	return result;
}

HRESULT DllRegister(HINSTANCE module, LPCWSTR officeApplication, DWORD addinLoadBehavior, DWORD addinCommandLineSafe, LPCWSTR progId, LPCWSTR classId, LPCWSTR friendlyName, LPCWSTR description, LPCWSTR version, RegisterMode mode)
{
	HRESULT result = S_OK;

	result = RegisterCOMComponent(module, officeApplication, progId, classId, version, description, mode);
	if (S_OK == result)
		result = RegisterCOMAddin(officeApplication, progId, friendlyName, description, addinLoadBehavior, addinCommandLineSafe, 0 == mode);

	return result;
}

HRESULT DllUnregister(LPCWSTR officeApplication, LPCWSTR progId, LPCWSTR classId, LPCWSTR version, RegisterMode mode)
{
	HRESULT result = S_OK;

	result = UnRegisterCOMAddin(officeApplication, progId);
	if (S_OK == result)
		result = UnregisterCOMComponent(officeApplication, progId, classId, version, mode);

	return result;
}
