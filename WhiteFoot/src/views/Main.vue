<template >

  <v-container
  fluid
  >
   <v-carousel
    cycle
    height="400"
    hide-delimiter-background
    show-arrows-on-hover
  >
    <v-carousel-item
      v-for="(slide, i) in slides"
      :key="i"
    >
      <v-img
        height="388px"
        :src="slide"
      ></v-img>
    </v-carousel-item>
  </v-carousel>
  <v-row>
    <v-divider></v-divider>
  </v-row>
  <v-row>
    <v-col></v-col>
    <v-row aria-rowspan="2">
      <v-col>Best Seller</v-col>
    </v-row>

  </v-row>
  <v-row justify= "space-around">
      <v-col
      v-for="item in BEST_SELLERS"
      :key="item.name"
      cols="3"
      >
        <v-card
        class="pa-3"
        outlined
        align="center"
        >
        <v-img
          height="388px"
          :src="item.url"
        ></v-img>
        {{item.name}}
        </v-card>
      </v-col>
  </v-row>

  </v-container>
</template>

<script>
 export default {
    data () {
      return {
        slides: [
          'https://8tontruck.com/web/upload/NNEditor/20210125/96e30568b1a217f5563b7b62cb4e4365.jpg',
          'https://8tontruck.com/web/upload/NNEditor/20210125/9a9b04621e32d69fb5df04f1e52b6795.jpg',
          'https://8tontruck.com/web/upload/NNEditor/20210125/258d42e256b72cd4fc7694ff084eab4f.jpg',
        ],
        BEST_SELLERS: [
          {
            name: '푸들푸들',
            url: 'https://8tontruck.com/web/product/big/202105/88a1cae14803a6b9770e11720260a0d2.jpg',
          },
          {
            name: '파스텔프레임',
            url: 'https://8tontruck.com/web/product/big/202105/3b31243df9aa0e852dd8cec951cb98ef.jpg',
          },
          {
            name: '유광파스텔단색',
            url: 'https://8tontruck.com/web/product/big/202101/50b3ae1f78dea1f1fa5f2fb17dd9bad6.jpg',
          },
          {
            name: '안녕제주',
            url: 'https://8tontruck.com/web/product/big/202105/9a92a716a9ec2d957169ac0211c54986.jpg',
          },
          {
            name: '99.9% 항균케이스',
            url: 'https://8tontruck.com/web/product/big/202106/a6e9293902b6e64983e649c2a1ee9292.png',
          },
          {
            name: '용가리 프레임',
            url: 'https://8tontruck.com/web/product/big/202105/e8be209f0902d8d4bda9fd91379d679d.jpg',
          },
          {
            name: '곰도리',
            url: 'https://8tontruck.com/web/product/big/202105/e83bf2669e34a4066fe3fe8a89e8de26.jpg',
          },
        ],
      }
    },
  }
</script>