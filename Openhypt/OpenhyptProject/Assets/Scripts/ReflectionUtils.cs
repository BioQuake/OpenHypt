using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class ReflectionUtils {

    public static object GetFieldValue(object target, string typename, string fieldname)
	{
        object result = null;

        Type ObjType = Type.GetType(typename);
        if (ObjType != null)
		{
            FieldInfo field = ObjType.GetField(fieldname);
            if (field != null)
			{
				result = field.GetValue(target);
			}
            else
            {
                Debug.LogError(string.Format("Failed to find field {0} on type {1} to get!", fieldname, typename));
            }
        }
        else
        {
            Debug.LogError(string.Format("Failed to find type {0} when getting field {1}!", typename, fieldname));
        }

        return result;
	}

    public static T GetFieldValue<T>(object target, string typename, string fieldname)
    {
        return (T)GetFieldValue(target, typename, fieldname);
    }
    
    public static void SetField(object target, string typename, string fieldname, object value)
	{
        Type ObjType = Type.GetType(typename);
        if (ObjType != null)
        {
            FieldInfo field = ObjType.GetField(fieldname);
            if (field != null)
            {
                try
                {
                    field.SetValue(target, value);
                }
                catch (ArgumentException e)
				{
                    Debug.LogError(string.Format("Type mismatch setting field {0} on type {1}!", fieldname, typename));
				}
            }
            else
            {
                Debug.LogError(string.Format("Failed to find field {0} on type {1} to set!", fieldname, typename));
            }
        }
		else
		{
            Debug.LogError(string.Format("Failed to find type {0} when setting field {1}!", typename, fieldname));
		}
    }

    public static void InvokeVoid0(object target, string typename, string methodname)
	{
        Type ObjType = Type.GetType(typename);
        if (ObjType != null)
        {
            MethodInfo method = ObjType.GetMethod(methodname);
            if (method != null)
            {
                try
                {
                    method.Invoke(target, null);
                }
                catch (TargetParameterCountException e)
                {
                    Debug.LogError(string.Format("Method {0} on type {1} does not have 0 parameters!", methodname, typename));
                }
                catch (ArgumentException e)
				{
                    Debug.LogError(string.Format("Method {0} on type {1} does not have 0 parameters!", methodname, typename));
				}
            }
            else
            {
                Debug.LogError(string.Format("Failed to find method {0} on type {1} to invoke!", methodname, typename));
            }
        }
        else
        {
            Debug.LogError(string.Format("Failed to find type {0} when invoking method {1}!", typename, methodname));
        }
    }
}
