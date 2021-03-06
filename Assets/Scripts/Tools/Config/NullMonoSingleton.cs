﻿using System;

public class NullMonoSingleton<T> where T : new()  
{  
	protected NullMonoSingleton()  
	{  
		if (Instance != null)  
		{  
			throw (new Exception("You have tried to create a new singleton class where you should have instanced it. Replace your \"new class()\" with \"class.Instance\""));  
		}  
	}  
	
	public static T Instance  
	{  
		get  
		{  
			return SingletonCreator.instance;  
		}  
	}  
	
	class SingletonCreator  
	{  
		static SingletonCreator()  
		{  
			
		}  
		internal static readonly T instance = new T();  
	}  
} 

 


