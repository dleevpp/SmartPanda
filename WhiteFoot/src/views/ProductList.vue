<template >
  <v-container
  fluid
  >

  <v-row justify= "space-around">
      <v-col
      v-for="item in products"
      :key="item.name"
      cols="3"
      >
        <v-card
        class="pa-3"
        outlined
        align="center"
        :to="`/product?id=${item.id}`"
        >
        <v-img
          height="388px"
          :src="item.url"
        ></v-img>
        {{item.name}}
        <v-spacer/>
        {{item.price}}원
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
        products: [
          {
            name: '푸들푸들',
            url: 'https://8tontruck.com/web/product/big/202105/88a1cae14803a6b9770e11720260a0d2.jpg',
            price: 100,
          },
          {
            name: '파스텔프레임',
            url: 'https://8tontruck.com/web/product/big/202105/3b31243df9aa0e852dd8cec951cb98ef.jpg',
            price: 100,
          },
          {
            name: '유광파스텔단색',
            url: 'https://8tontruck.com/web/product/big/202101/50b3ae1f78dea1f1fa5f2fb17dd9bad6.jpg',
            price: 100,
          },
          {
            name: '안녕제주',
            url: 'https://8tontruck.com/web/product/big/202105/9a92a716a9ec2d957169ac0211c54986.jpg',
            price: 100,
          },
          {
            name: '99.9% 항균케이스',
            url: 'https://8tontruck.com/web/product/big/202106/a6e9293902b6e64983e649c2a1ee9292.png',
            price: 100,
          },
          {
            name: '용가리 프레임',
            url: 'https://8tontruck.com/web/product/big/202105/e8be209f0902d8d4bda9fd91379d679d.jpg',
            price: 100,
          },
          {
            name: '곰도리',
            url: 'https://8tontruck.com/web/product/big/202105/e83bf2669e34a4066fe3fe8a89e8de26.jpg',
            price: 100,
          },
        ],
      }
    },
    methods: {
      moveToProductPage(id) {
        
      }
    }
  }
</script>