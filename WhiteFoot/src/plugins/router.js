import Vue from 'vue'
import VueRouter from 'vue-router'
import Main from '@/views/Main'
import About from '@/views/About'
import Cart from '@/views/Cart'
import CustomerCenter from '@/views/CustomerCenter'
import Join from '@/views/Join'
import Login from '@/views/Login'
import MyPage from '@/views/MyPage'
import Orders from '@/views/Orders'
import ProductSubmit from '@/views/ProductSubmit'
import Product from '@/views/Product'
import Admin from '@/views/Admin'
import auth from '@/auth'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Main',
    component: Main,
    meta: { requiresAuth: false }
  },
  {
    path: '/admin',
    name: 'Admin',
    component: Admin,
    meta: { requiresAuth: true }
  },
  {
    path: '/about',
    name: 'About',
    component: About,
    meta: { requiresAuth: true }
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    //component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/cart',
    name: 'Cart',
    component: Cart,
    meta: { requiresAuth: true }
  },
  {//고객센터
    path: '/customer-center',
    name: 'Customer center',
    component: CustomerCenter,
    meta: { requiresAuth: false }
  },
  {//회원가입
    path: '/join',
    name: 'Join',
    component: Join,
    meta: { requiresAuth: false }
  },
  {//로그인
    path: '/login',
    name: 'Login',
    component: Login,
    meta: { requiresAuth: false }
  },
  {//마이페이지
    path: '/mypage',
    name: 'MyPage',
    component: MyPage,
    meta: { requiresAuth: true }
  },
  {//주문조회
    path: '/orders',
    name: 'Orders',
    component: Orders,
    meta: { requiresAuth: true }
  },
  {//상품등록
    path: '/product-submit',
    name: 'ProductSubmit',
    component: ProductSubmit,
    meta: { requiresAuth: true }
  },
  {//상품 정보
    path: '/product',
    name: 'Product',
    component: Product,
    meta: { requiresAuth: true }
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth) && !auth.loggedIn()) {
    next({
      path: '/login',
      query: { redirect: to.fullPath }
    })
  }
  else
    next()
})

export default router
