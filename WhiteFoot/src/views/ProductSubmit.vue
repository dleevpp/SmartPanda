<template>
  <v-container>
    <v-row>
      <v-col>
        <v-file-input
          label="사진 첨부"
          filled
          prepend-icon="mdi-camera"
          v-model="image"
          accept=".png"
        ></v-file-input>
      </v-col>
      <v-col>
        <v-row>
        <v-col>
          상품이름
        </v-col>
        <v-col
          cols="12"
          sm="6"
        >
        <v-textarea
          label="상품이름"
          auto-grow
          outlined
          rows="1"
          row-height="15"
          v-model="name"
        ></v-textarea>
      </v-col>
      </v-row>
      <v-row>
        <v-col>
          가격
        </v-col>
        <v-col
          cols="12"
          sm="6"
        >
        <v-textarea
          label="가격"
          auto-grow
          outlined
          rows="1"
          row-height="15"
          v-model="price"
        ></v-textarea>
      </v-col>
      </v-row>
      <v-row>
        <v-col>
          제조사
        </v-col>
        <v-col
        cols="12"
        sm="6"
      >
        <v-textarea
          label="제조사"
          auto-grow
          outlined
          rows="1"
          row-height="15"
          v-model="company"
        ></v-textarea>
      </v-col>
      </v-row>
      <v-row>
        <v-col>
          제조국가
        </v-col>
        <v-col
        cols="12"
        sm="6"
      >
        <v-textarea
          label="제조국가"
          auto-grow
          outlined
          rows="1"
          row-height="15"
          v-model="country"
        ></v-textarea>
      </v-col>
      </v-row>
      <v-row>
        <v-col>
          상품 분류
        </v-col>
        <v-col
          cols="12"
          sm="6"
        >
          <v-radio-group v-model="category" row mandatory>
          <v-radio
            v-for="n in ['케이스', '악세서리']"
            :key="n"
            :label="n"
            :value="n"
          ></v-radio>
          </v-radio-group>
        </v-col>
      </v-row>
      </v-col>
    </v-row>
    <v-row><v-divider></v-divider></v-row>
    <v-row><v-spacer></v-spacer></v-row>
    <v-row>
      <v-col class="text-right">
        <v-btn class="ar-4" color="primary" @click="submit">등록하기</v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import axios from '../axios'
import auth from '../auth'

export default {
    data() {
      return {
        image: null,
        name: "",
        price: 0,
        company: "",
        country: "",
        category: "",
      }
    },
    methods: {
      submit() {
        axios.post('Product', {
          Image: this.image.name,
          Name: this.name,
          Price: this.price,
          Company: this.company,
          Country: this.country,
          Category: this.category,
        }, auth.axiosConfig)
          .then(() => {
            this.image = ""
            this.name = ""
            this.price = 0
            this.company = ""
            this.country = ""
            this.category = ""
          })
          .catch(e => console.log(e))
      }
    }
  }
</script>