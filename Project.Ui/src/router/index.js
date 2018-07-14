import Vue from 'vue'
import Router from 'vue-router'

import Auth from '@/common/auth'

import Template from '@/template/index'
import Home from '@/views/home'
import Authorized from '@/views/authorized'

import routersgenerated from './generated'

Vue.use(Router)


let childrens = routersgenerated.concat([
    {
        path: 'home',
        name: 'Home',
        component: Home
    },
]);

const router = new Router({
    mode: 'history',
    routes: [
        {
            path: '/authorized',
            name: 'Authorized',
            component: Authorized,
        },
        {
            path: '/',
            redirect: '/home',
            component: Template,
            meta: { requiresAuth: true },
            children: childrens
        },

    ]
})

router.beforeEach(async (to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
        if (!Auth.logged()) {
            Auth.login();
            return;
        }
    }
    next();
});


export default router;
