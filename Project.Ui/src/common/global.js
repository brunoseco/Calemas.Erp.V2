export default {

    END_POINT_DEFAULT: process.env.VUE_APP_ENDPOINT_DEFAULT,
    
    SSO_END_POINT: process.env.VUE_APP_ENDPOINT_SSO,

    SSO_REDIRECT_LOGIN_URL: process.env.VUE_APP_LOCATION_URL + "authorized/?",
    SSO_REDIRECT_LOGOUT_URL: process.env.VUE_APP_LOCATION_URL + "loggedout/?",

    SSO_CLIENT_ID: "calemaserp-spa",
    SSO_RESPONSE_TYPE: "id_token token",
    SSO_SCOPE: "openid calemaserp profile email",

    ACCESS_TOKEN: "ACCESS_TOKEN",
    ID_TOKEN: "ID_TOKEN",
    USER_INFO: "USER_INFO",
    ID_STATE: "ID_STATE",

    URL_PORTAL_CORPORATIVO: process.env.VUE_APP_PORTAL_CORPORATIVO,
    URL_DOWNLOAD: process.env.VUE_APP_ENDPOINT_DOWNLOAD + '/document/download/',


}
