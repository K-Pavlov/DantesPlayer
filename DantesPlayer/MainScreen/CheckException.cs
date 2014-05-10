namespace MainScreen
 {
     #region Namespaces
     using System;
     using System.Diagnostics;
     #endregion
    /// <summary>
    /// Checks for exception 
    /// </summary>
     public static class CheckException
     {
         /// <summary>
         /// Returns true if not null
         /// </summary>
         /// <param name="objectToCheck">Any object</param>
         /// <returns></returns>
         public static bool CheckNull(object objectToCheck)
         {
             bool isNotNull = objectToCheck != null;
             return isNotNull;
         }   
     }
 }
