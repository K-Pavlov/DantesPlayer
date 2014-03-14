namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Diagnostics;
    #endregion
    public static class CheckException
    {
        /// <summary>
        /// Returns true if not null
        /// </summary>
        /// <param name="objectToCheck"></param>
        /// <returns></returns>
        public static bool CheckNull(object objectToCheck)
        {
            bool isNotNull = objectToCheck != null;
            if (isNotNull)
            {
                if (objectToCheck.GetType() != typeof(Nullable<>))
                {
                    Debug.Write("WARINING : Type ");
                    Debug.Write(objectToCheck.GetType().Name);
                    Debug.WriteLine(" cannot be null, no need for explict checking.");
                }
            }
            return isNotNull;
        }   
    }
}
