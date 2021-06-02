import Vue from 'vue'
import VueRouter from 'vue-router'
import Main from '../views/Main'
import About from '@/views/About'
import Cart from '@/views/Cart'
import customer_center from '@/views/customer_center'
import Join from '@/views/Join'
import Login from '@/views/Login'
import MyPage from '@/views/MyPage'
import Order_list from '@/views/Order_list'
import _product_submit from '@/views/_product_submit'
import Product from '@/views/Product'
import Admin from '@/views/Admin'
import member_inform from '@/views/member_inform'
import product_control from '@/views/product_control'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Main',
    component: Main
  },
  {
    path: '/member_inform',
    name: 'member_inform',
    component: member_inform
  },
  {
    path: '/product_control',
    name: 'product_control',
    component: product_control
  },
  {
    path: '/admin',
    name: 'Admin',
    component: Admin
  },
  {
    path: '/about',
    name: 'About',
    component: About
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    //component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/Cart',
    name: 'Cart',
    component: Cart
  },
  {//고객센터
    path: '/customer_center',
    name: 'customer_center',
    component: customer_center
  },
  {//회원가입
    path: '/Join',
    name: 'Join',
    component: Join
  },
  {//로그인
    path: '/Login',
    name: 'Login',
    component: Login
  },
  {//마이페이지
    path: '/MyPage',
    name: 'MyPage',
    component: MyPage
  },
  {//주문조회
    path: '/Order_list',
    name: 'Order_list',
    component: Order_list
  },
  {//상품등록
    path: '/_product_submit',
    name: 'product_submit',
    component: _product_submit
  },
  {//상품 정보
    path: '/Product',
    name: 'Product',
    component: Product
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
