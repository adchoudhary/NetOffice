#pragma once

#define WIN32_LEAN_AND_MEAN

#include "targetver.h"
#include <windows.h>
#include <mscoree.h>

//
// Import Type Libraries
//
#import <mscorlib.tlb>  raw_interfaces_only high_property_prefixes("_get","_put","_putref")  rename("ReportEvent", "MsCorLib_ReportEvent")


//
// Macros
//
#define IfFalseGo(x) { b=(x); if (FALSE == b) {hr = E_FAIL; goto Error;} }
#define IfFailGo(x) { hr=(x); if (FAILED(hr)) goto Error; }
#define IfNullGo(p) { if(!p) {hr = E_FAIL; goto Error; } }
#define ValidateExtensibilityFail(x) { if(EXTENSIBILITY_FAIL_RESULT != E_NOTIMPL) x = EXTENSIBILITY_FAIL_RESULT; }
