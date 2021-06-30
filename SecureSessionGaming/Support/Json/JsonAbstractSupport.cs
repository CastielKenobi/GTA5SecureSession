using System;
using System.IO;
using Newtonsoft.Json;
using SecureSessionGaming.Exceptions;
using SecureSessionGaming.Support.Log;

namespace SecureSessionGaming.Support.Json
{
    public abstract class JsonAbstractSupport<T>
    {
        private string jsonFile;

        protected T objectHandler;

        public JsonAbstractSupport()
        {
        }

        protected void SetFile(string filename)
        {
            this.jsonFile = AppDomain.CurrentDomain.BaseDirectory
                + Path.DirectorySeparatorChar
                + filename;
        }

        protected void CreateDefault()
        {
            if (!Exists())
            {
                LogSupport.Debug(
                    jsonFile + " does not exists, creating"
                );
                Save();
            }
        }

        protected void Save()
        {
            LogSupport.Debug("Saving settings to " + this.jsonFile);
            try
            {
                File.WriteAllText(
                    this.jsonFile,
                    JsonConvert.SerializeObject(objectHandler, Formatting.Indented)
                );
            }
            catch (IOException e)
            {
                LogSupport.Error(
                    AppException.EXCEPTION_SETTINGS_SAVE_ERROR + ": " + e.Message
                );
                throw new AppException(
                    AppException.EXCEPTION_SETTINGS_SAVE_ERROR,
                    e.Message
                );
            }
        }

        protected void Load()
        {
            LogSupport.Debug("Loading settings");
            try
            {
                objectHandler = JsonConvert.DeserializeObject<T>(
                    File.ReadAllText(this.jsonFile)
                );
            }
            catch (Exception e)
            {
                LogSupport.Error(
                    AppException.EXCEPTION_SETTINGS_LOAD_ERROR + ": " + e.Message
                );
                throw new AppException(
                    AppException.EXCEPTION_SETTINGS_LOAD_ERROR,
                    e.Message
                );
            }
        }

        protected bool Exists()
        {
            return File.Exists(this.jsonFile);
        }

        public void Destroy()
        {
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(this.jsonFile))
                {
                    LogSupport.Debug(
                        "Removing settings"
                    );
                    File.Delete(this.jsonFile);
                }
            }
            catch (IOException e)
            {
                LogSupport.Error(
                    AppException.EXCEPTION_SETTINGS_REMOVE_ERROR + ": " + e.Message
                );
                throw new AppException(
                    AppException.EXCEPTION_SETTINGS_REMOVE_ERROR,
                    e.Message
                );
            }
        }
    }
}
