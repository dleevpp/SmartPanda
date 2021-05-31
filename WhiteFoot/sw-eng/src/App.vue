<template>
  <div>
    <h1> Smart Panda {{animal}}</h1>
    <h2> 한수는 {{food}} 를 좋아합니다.</h2>
    <h3 v-text = "food"></h3>
    <input type = "text" v-model = "food"/>
    <div v-html="alertMessage"></div>
    <div v-html = "subscribeHTML"></div>
    <img v-bind:src = "imageSource" alt="random">
    <a :href="food">{{food}}</a>
    <hr/>
    <h2 v-bind:class="{ orange : food==='orange','not-good': food!=='orange' }">한수는 {{food}}를 좋아합니다</h2>
  </div>
  <div id="app">
  <v-app id="inspire">
    <v-card class="overflow-hidden">
      <v-app-bar
        absolute
        color="white"
        elevate-on-scroll
        scroll-target="#scrolling-techniques-7"
      >
        <v-app-bar-nav-icon></v-app-bar-nav-icon>
  
        <v-toolbar-title>Title</v-toolbar-title>
  
        <v-spacer></v-spacer>
  
        <v-btn icon>
          <v-icon>mdi-magnify</v-icon>
        </v-btn>
  
        <v-btn icon>
          <v-icon>mdi-heart</v-icon>
        </v-btn>
  
        <v-btn icon>
          <v-icon>mdi-dots-vertical</v-icon>
        </v-btn>
      </v-app-bar>
      <v-sheet
        id="scrolling-techniques-7"
        class="overflow-y-auto"
        max-height="600"
      >
        <v-container style="height: 1500px;">
        </v-container>
      </v-sheet>
    </v-card>
  </v-app>
</div>
</template>
//화면

//기능
<script>
export default {
  name: 'App',
  data(){
    return {
      animal : "BIGPanda",
      food : "풀",
      alertMessage:"<h2>경고!!!<h2/>",
      subscribeHTML: `<button onclick="document.querySelector('body').style.display= 'none'">구독하기</button>`,
      imageSource : "https://placeimg.com/100/100/any",
      naverUrl: "https://www.naver.com",
    };
  }
};
</script>

//디자인
<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
input{
  font-size :20px;
}
.orange{
  color:orange;

}

.salmon{
  color: salmon;
}

.red{
  color:red;
}
.not-good{
  text-decoration: line-through;
}
</style>
