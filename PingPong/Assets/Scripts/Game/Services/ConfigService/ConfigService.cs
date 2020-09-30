using UnityEngine;

namespace Game.Services.ConfigService
{
    public class ConfigService : IConfigService
    {

        private const string CONFIG_RESOURCE_PATH = "Config/Config";

        private Config _config;

        public Config Config
        {
            get
            {
                if (_config == null)
                {
                    _config = Resources.Load<Config>(CONFIG_RESOURCE_PATH);
                }

                return _config;
            }
        }
    }
}
