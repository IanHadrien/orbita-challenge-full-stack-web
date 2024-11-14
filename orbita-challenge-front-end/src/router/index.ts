import { createRouter, createWebHistory } from 'vue-router'

import LayoutApp from '../pages/_layouts/app.vue'
import Students from '@/pages/app/student/students.vue'
import About from '@/pages/app/about.vue'
import SignIn from '@/pages/auth/sign-in.vue'
import SignUp from '@/pages/auth/sign-up.vue'

const routes = [
  {
    path: '/',
    component: LayoutApp,
    children: [
      {
        path: '/students',
        name: 'home',
        component: Students,
        meta: { requiresAuth: true }
      },
      {
        path: '/',
        name: 'About',
        component: About,
        meta: { requiresAuth: true }
      }
    ]
  },
  {
    path: '/',
    children: [
      {
        path: '/sign-in',
        name: 'SignIn',
        component: SignIn,
      },
      {
        path: '/sign-up',
        name: 'SignUp',
        component: SignUp,
      }
    ]
  },
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

router.beforeEach((to, from, next) => {
  if (to.meta.requiresAuth && !isAuthenticated()) {
    next({ name: 'SignIn' });
  } else {
    next();
  }
});

function isAuthenticated() {
  return !!localStorage.getItem('@authToken');
}

export default router
