using System;

namespace HRCountriesServicesSolution.Constant
{
    /// <summary>
    /// All centralized contants
    /// </summary>
    static public class WEBCONFIG
    {
        /// <summary>
        /// Cle webConfig webcamsTravelLogin
        /// </summary>
        public static String WEBCAMSTRAVEL_LOGIN_KEY = "webcamsTravelLogin";
        /// <summary>
        /// Cle webConfig WEBCAMSTRAVEL_PWD_KEY
        /// </summary>
        public static String WEBCAMSTRAVEL_PWD_KEY = "webcamsTravelPwd";
        /// <summary>
        /// Cle webConfig WEBCAMSTRAVEL_URL_KEY
        /// </summary>
        public static String WEBCAMSTRAVEL_URL_KEY = "connectWebcamsTravelsURL";
        /// <summary>
        /// Cle webConfig GEONAME_SEARCHJSON_URL_KEY
        /// </summary>
        public static String GEONAME_SEARCHJSON_URL_KEY = "GEONAME_SEARCHJSON_URL_KEY";
        /// <summary>
        /// Cle webConfig GEONAME KY
        /// </summary>
        public static String GEONAME_KEY = "GeonameKey";

    }
    /// <summary>
    /// Constants used by Region stub (available on azure deployment)
    /// </summary>
    static public class REGION_STUB
    {
        /// <summary>
        /// Africa Region
        /// </summary>
        public static String AFRICA_REGION = "Africa";
        /// <summary>
        /// Americas Region
        /// </summary>
        public static String AMERICAS_REGION = "Americas";
        /// <summary>
        /// Asia Region
        /// </summary>
        public static String ASIA_REGION = "Asia";
        /// <summary>
        /// Europe Region
        /// </summary>
        public static String EUROPE_REGION = "Europe";
        /// <summary>
        /// Oceania Region
        /// </summary>
        public static String OCEANIA_REGION = "Oceania";
        /// <summary>
        /// Polar Region
        /// </summary>
        public static String POLAR_REGION = "Polar";
    }

    /// <summary>
    /// Stub constants of json Boundaries
    /// </summary>
    static public class BOUNDARIES_STUB
    {
        /// <summary>
        /// Name of alpha3Code properties in Boundaries Stub
        /// </summary>
        public static String ISO3_PROPERTIE_NAME = "ISO3";
        /// <summary>
        /// Error message when boundaries repository contains no data
        /// </summary>
        public static String NO_DATA_ERROR_MESSAGE = "No boundaries data available";
    }
    /// <summary>
    /// Stub constants of json Countries Iteration
    /// </summary>
    static public class COUNTRIESITERATION_STUB
    {
        /// <summary>
        /// AllCountries json URL
        /// </summary>
        public static String COUNTRIES_JSON_URL = "~/App_Data/allCountries.json";
        /// <summary>
        /// Boundaries json URL
        /// </summary>
        public static String BOUNDARIES_JSON_URL = "~/App_Data/Boundaries.json";
    }
    /// <summary>
    /// 
    /// </summary>
    static public class COUNTRIESITERATION
    {
        /// <summary>
        /// 
        /// </summary>
        public static String COUNTRIESITERATION_REPOSITORY_ERROR_DESCRIPTION = "CountriesIteration Repository unavailable";
        /// <summary>
        /// 
        /// </summary>
        public static String COUNTRIESITERATION_SERVICE_ERROR_DESCRIPTION = "CountriesIterationService unavailable";
    }
    /// <summary>
    /// 
    /// </summary>
    static public class BOUNDARIES
    {
        /// <summary>
        /// 
        /// </summary>
        public static String BORDER_REPOSITORY_ERROR_DESCRIPTION = "Border Repository unavailable";
        /// <summary>
        /// 
        /// </summary>
        public static string BORDER_SERVICE_ERROR_DESCRIPTION = "_BorderService unavailable";
    }
    /// <summary>
    /// 
    /// </summary>
    static public class COUNTRIES
    {
        /// <summary>
        /// 
        /// </summary>
        public static String COUNTRIES_REPOSITORY_ERROR_DESCRIPTION = "Country Repository unavailable";
        /// <summary>
        /// 
        /// </summary>
        public static String COUNTRIES_SERVICE_ERROR_DESCRIPTION = "Country Service unavailable";

    }
    /// <summary>
    /// 
    /// </summary>
    static public class GEONAME
    {
        /// <summary>
        /// 
        /// </summary>
        public static String PLACENAME_PARAMETER = "q";
        /// <summary>
        /// 
        /// </summary>
        public static String USERNAME_PARAMETER = "username";
        /// <summary>
        /// 
        /// </summary>
        public static String COUNTRY_PARAMETER = "country";
        /// <summary>
        /// 
        /// </summary>
        public static String REST_CLIENT_NOT_INITIALIZED = "HRGeonameRestClient not initialised";
    }

    /// <summary>
    /// 
    /// </summary>
    static public class REGION
    {
        /// <summary>
        /// 
        /// </summary>
        public static String REGION_REPOSITORY_ERROR_DESCRIPTION = "Region Repository unavailable";
        /// <summary>
        /// 
        /// </summary>
        public static string REGION_SERVICE_ERROR_DESCRIPTION = "_regionsService unavailable";
    }

    /// <summary>
    /// 
    /// </summary>
    static public class WEBCAMTRAVEL
    {
        /// <summary>
        /// 
        /// </summary>
        public static String LIMIT_KEY = "limit";
        /// <summary>
        /// 
        /// </summary>
        public static String OFFSET_KEY = "offset";
        /// <summary>
        /// 
        /// </summary>
        public static String LAT_KEY = "lat";
        /// <summary>
        /// 
        /// </summary>
        public static String LON_KEY = "lon";
        /// <summary>
        /// 
        /// </summary>
        public static String X_MASHAPE_KEY= "X-Mashape-Key";
        /// <summary>
        /// 
        /// </summary>
        public static String ACTIVE_STATUS = "active";
        /// <summary>
        /// 
        /// </summary>
        public static String INITIALISATION_ERROR_DESCRIPTION = "StructureMap error initiailisation";
        /// <summary>
        /// 
        /// </summary>
        public static String WEBCAMS_TRAVEL_SERVICE_ERROR_DESCRIPTION = "WebCams travel service unavailable";
    }

}