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
import axios from '../axios'
import auth from '../auth'

export default {
    data () {
      return {
        products: []
      }
    },
    created() {
      this.getProducts()
    },
    methods: {
      getProducts() {
        axios.get('Product/all', auth.axiosConfig)
          .then(res => this.products = res.data)
          .catch(e => console.log(e))
      }
    }
  }
</script>