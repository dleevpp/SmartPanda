<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      app
    >
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            SmartPanda
          </v-list-item-title>
          <v-list-item-subtitle />
        </v-list-item-content>
      </v-list-item>
      <v-divider />
      <v-list
        dense
        nav
      >
        <v-list-item
          v-for="item in items"
          :key="item.title"
          :to="item.to"
          link
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar app flat color="#F5DF4D">
      <v-app-bar-nav-icon @click="drawer = !drawer" />

      <v-toolbar-title style="width: 300px" class="font-weight-black">
        SmartPanda
      </v-toolbar-title>
      <v-tabs color="#939597" right>
        <v-tab :to="'/login'">
          <h3 class="font-weight-bold">로그인</h3>
        </v-tab>
        <v-tab :to="'/join'">
          <h3 class="font-weight-bold">회원가입</h3>
        </v-tab>
        <v-tab :to="'/orders'">
          <h3 class="font-weight-bold">주문조회</h3>
        </v-tab>
        <v-tab :to="'/customer-center'">
          <h3 class="font-weight-bold">고객센터</h3>
        </v-tab>

      </v-tabs>
    </v-app-bar>
    <v-row aria-rowspan="800px"></v-row>
    <v-row
    class="d-flex"
    justify="center">


    <v-banner min-height="500">

    <v-img
    :src="require('@/assets/PANDA.png')"
    :max-width="800"
    :background-position="center"
    >
    </v-img>
    </v-banner>
  </v-row>
  <v-container fluid>
    <v-toolbar
    dense
    outlined
    max-height="0">
      <v-tabs
        grow
        align-with-title
      >
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
            to='/product-list'
          >
            전체
          </v-tab>
        </template>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
            to='/product-list?company=애플'
          >
            애플
          </v-tab>
        </template>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
            to='/product-list?company=삼성'
          >
            삼성
          </v-tab>
        </template>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
            to='/product-list?category=케이스'
          >
            케이스
          </v-tab>
        </template>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
            to='/product-list?company=악세서리'
          >
            악세서리
          </v-tab>
        </template>
      </v-menu>
      </v-tabs>
    </v-toolbar>
  </v-container>
    <v-main>
      <v-container fluid>
      <router-view />
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
      drawer: null,
      items: [
        { title: '메인페이지', icon: 'mdi-home-variant-outline', to: '/'},
        { title: '마이페이지', icon: 'mdi-file-account-outline', to: '/mypage'},
        { title: '장바구니', icon: 'mdi-cart', to: '/cart'},
        { title: '주문조회', icon: 'mdi-lingerie', to: '/orders'},
        { title: '회원가입', icon: 'mdi-login-variant', to: '/join'},
        { title: '로그인', icon: 'mdi-key', to: '/login'},
        { title: '상품등록', icon:'mdi-briefcase-plus-outline', to:'/product-submit'},
        { title: '고객센터', icon: 'mdi-help-box', to: '/customer-center'},
      ],
     }),
  }
</script>
