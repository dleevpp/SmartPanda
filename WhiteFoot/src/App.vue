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
    <v-app-bar app>
      <v-app-bar-nav-icon @click="drawer = !drawer" />

      <v-toolbar-title>SmartPanda</v-toolbar-title>
      <v-col aria-colspan="7"></v-col>
      <v-col><v-btn href='login'>로그인</v-btn></v-col>
      <v-col><v-btn href='join'>회원가입</v-btn></v-col>
      <v-col><v-btn href='orders'>주문조회</v-btn></v-col>
      <v-col><v-btn href='customer-center'>고객센터</v-btn></v-col>
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
          >
            애플
          </v-tab>
        </template>
        <v-list>
          <v-list-item
            v-for="item in apple"
            :key="item.title"
            :to="item.to"
            link
          >
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
          >
            삼성
          </v-tab>
        </template>
        <v-list>
          <v-list-item
            v-for="item in samsung"
            :key="item.title"
            :to="item.to"
            link
          >
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
          >
            케이스
          </v-tab>
        </template>
        <v-list>
          <v-list-item
            v-for="item in cases"
            :key="item.title"
            :to="item.to"
            link
          >
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
          >
            필름
          </v-tab>
        </template>
        <v-list>
          <v-list-item
            v-for="item in film"
            :key="item.title"
            :to="item.to"
            link
          >
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="gray"
            v-bind="attrs"
            v-on="on"
          >
            충전용품
          </v-tab>
        </template>
        <v-list>
          <v-list-item
            v-for="item in charger"
            :key="item.title"
            :to="item.to"
            link
          >
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-tab
            color="primary"
            v-bind="attrs"
            v-on="on"
          >
            차량용품
          </v-tab>
        </template>
        <v-list>
          <v-list-item
            v-for="item in car"
            :key="item.title"
            :to="item.to"
            link
          >
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
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
          { title: '고객센터', icon: 'mdi-help-box', to: '/customer-center'},
        ],
              apple:[
              {title: '아이폰', to:'/'},
              {title: '애플워치', to:'/'},
              {title: '에어팟', to:'/'},
            ],
            samsung:[
              {title: '갤럭시', to:'/'},
              {title: '갤럭시워치', to:'/'},
              {title: '버즈', to:'/'}
            ],
            cases:[
              {title:'소재별', to:'/'},
              {title:'기능별', to:'/'}
            ],
            film:[
              {title:'소재별', to:'/'},
              {title:'기능별', to:'/'}
            ],
            charger:[
              {title:'고속 충전', to:'/'},
              {title:'보조배터리',to:'/'},
            ],
            car:[
              {title:'충전기', to:'/'},
              {title:'거치대', to:'/'}
            ],

     }),
  }
</script>
