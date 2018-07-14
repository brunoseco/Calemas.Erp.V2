import Cache from './cache'
import Global from './global'
import { Api } from './api'

export default {

    authorize_url: Global.SSO_END_POINT + 'connect/authorize',
    addclaims_authorize_url: Global.SSO_END_POINT + '/accountafterauth/claimsadd',
    endsession_url: Global.SSO_END_POINT + 'connect/endsession',
    redirect_uri: Global.SSO_REDIRECT_LOGIN_URL,
    post_logout_redirect_uri: Global.SSO_REDIRECT_LOGOUT_URL,

    client_id: Global.SSO_CLIENT_ID,
    response_type: Global.SSO_RESPONSE_TYPE,
    scope: Global.SSO_SCOPE,

    getToken: function () {
        return Cache.get(Global.ID_TOKEN);
    },

    getState: function () {
        return Cache.get(Global.ID_STATE);
    },

    logged: function () {
        return Cache.get(Global.ID_TOKEN);
    },

    login: function () {

        Cache.add(Global.ID_STATE, Date.now());

        var url = this.authorize_url + "?" +
            "client_id=" + encodeURIComponent(this.client_id) + "&" +
            "redirect_uri=" + encodeURIComponent(this.redirect_uri) + "&" +
            "response_type=" + encodeURIComponent(this.response_type) + "&" +
            "scope=" + encodeURIComponent(this.scope) + "&" +
            "state=" + encodeURIComponent(this.getState()) + "&" +
            "nonce=xyz";

        window.location = url;
    },

    getCurrentUser: function (callback) {
        var api = new Api("currentuser");
        api.hasDefaultFilters = false;
        api.get().then(response => {
            var user = response.data;
            Cache.add(Global.USER_INFO, JSON.stringify(user));
            callback(user);
        });
    },

    currentUser: function () {
        var _user = JSON.parse(Cache.get(Global.USER_INFO));
        return _user;
    },

    logout: function () {

        var url = this.endsession_url + "?" +
            "id_token_hint=" + this.getToken() + "&" +
            "post_logout_redirect_uri=" + encodeURIComponent(this.post_logout_redirect_uri) + "&" +
            "state=" + encodeURIComponent(this.getState());

        this.reset();

        window.location = url;
    },

    verifyLogin: function () {

        if (window.location.href.indexOf("access_token") < 0)
            window.location = '/';

        this.reset();
        
        var itens = window.location.hash.split('#');
        var result = itens[1].split('&').reduce(function (result, item) {
            var parts = item.split('=');
            result[parts[0]] = parts[1];
            return result;
        }, {});

        Cache.add(Global.ACCESS_TOKEN, result.access_token, result.expires_in);
        Cache.add(Global.ID_TOKEN, result.id_token, result.expires_in);

        this.getCurrentUser(() => { setTimeout(() => { window.location = '/'; }, 500); });
    },

    claimsAddLoginSso: function (claim_type, claim_value) {

        Cache.add(Global.ID_STATE, Date.now());

        let url = this.addclaims_authorize_url + "?" +
            "claims_type=" + encodeURIComponent(claim_type) + "&" +
            "claims_value=" + encodeURIComponent(claim_value) + "&" +
            "client_id=" + encodeURIComponent(this.client_id) + "&" +
            "redirect_uri=" + encodeURIComponent(this.redirect_uri) + "&" +
            "response_type=" + encodeURIComponent(this.response_type) + "&" +
            "scope=" + encodeURIComponent(this.scope) + "&" +
            "state=" + encodeURIComponent(this.getState())

        Cache.remove(Global.USER_INFO);

        window.location = url;
    },

    reset: function () {

        Cache.remove(Global.ACCESS_TOKEN);
        Cache.remove(Global.ID_TOKEN);
        Cache.remove(Global.USER_INFO);

    }
}
