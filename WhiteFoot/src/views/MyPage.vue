<template >
  <v-container
  fluid
  >
    <v-row
      justify= "space-around">
        <th>마이페이지</th>
    </v-row>
    <v-row>
      <v-card class="mx-auto" min-width="1000px">
        <v-card-text class="grey lighten-4">
          <v-row>
            <v-col>
              {{user.username}}님
            </v-col>
            <v-col>
              <th>포인트</th>
            </v-col>
            <v-col>
              <th>쿠폰</th>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              {{getUserRoleText()}}
            </v-col>
            <v-col>
              {{user.point}}P
            </v-col>
            <v-col>
              1장
            </v-col>
          </v-row>
        </v-card-text>

        <v-space></v-space>

        <v-card-text>
          <v-row>
            <v-col>
              <th>주소</th>
            </v-col>
            <v-col>
              {{user.address1}}
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <th>상세 주소</th>
            </v-col>
            <v-col>
              {{user.address2}}
            </v-col>
          </v-row>
        </v-card-text>
      </v-card>

    </v-row>
  </v-container>
</template>

<script>
import axios from '../axios'
import auth from '../auth'

export default {
  data() {
    return {
      user: {
        username: "",
        address1: "",
        address2: "",
        point: 0
      }
    }
  },
  created() {
    console.log("created")
    this.getCurrentUser()
  },
  methods: {
    getCurrentUser() {
      const username = localStorage.getItem('username')
      console.log(username)
      axios.get(`User?username=${username}`, auth.axiosConfig)
        .then(res => this.user = res.data)
        .catch(e => console.log(e))
    },
    getUserRoleText() {
      const role = localStorage.getItem('role')
      if (role === "Admin")     return '관리자'
      if (role === "Seller")    return '사업자 회원'
      if (role === "Customer")  return '개인 회원'
      return ''
    }
  }
}
</script>
<style lang="">

</style>
