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

      <v-toolbar-title>Application</v-toolbar-title>
    </v-app-bar>

    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
      drawer: null,
              items: [
          { title: '메인페이지', icon: 'mdi-home-variant-outline', to: '/Main'},
          { title: '마이페이지', icon: 'mdi-help-box', to: '/MyPage'},
          { title: '주문조회', icon: 'mdi-help-box', to: '/Order_list'},
          { title: '회원가입', icon: 'mdi-help-box', to: '/Join'},
          { title: '로그인', icon: 'mdi-help-box', to: '/Login'},
          { title: '고객센터', icon: 'mdi-help-box', to: '/customer_center'},
        ],
     }),
  }
</script>
