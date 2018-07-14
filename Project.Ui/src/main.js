import Vue from 'vue'
import App from './App.vue'
import router from './router/index.js'
import './common/select'
import './common/datepicker'

import BootstrapVue from 'bootstrap-vue'
Vue.use(BootstrapVue);

import Notifications from 'vue-notification'
Vue.use(Notifications)

import VueTheMask from 'vue-the-mask'
Vue.use(VueTheMask)

import money from 'v-money'
Vue.use(money)

import '@coreui/icons/css/coreui-icons.min.css'
import 'flag-icon-css/css/flag-icon.min.css'
import 'font-awesome/css/font-awesome.min.css'
import 'simple-line-icons/css/simple-line-icons.css'
import './assets/scss/style.scss'

Vue.config.productionTip = false

Vue.prototype.$eventHub = new Vue();

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
