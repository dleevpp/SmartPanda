<template >
  <div>
    <v-container fluid>
      <v-col cols="20"
        align="center">
        <v-card
        max-width="800"
        justify= "space-around">
          <v-card-title>
            <v-card-text>
          <v-form>
          <v-text-field
            label="아이디"
            v-model="username"
            required
          ></v-text-field>
    </v-form>
    <v-form>
          <v-text-field
            type="password"
            label="비밀번호"
            v-model="password"
            required
          ></v-text-field>
    </v-form>
    <v-col class="text-right">
      <v-btn
        class="ar-4"
        type="submit"
        color="primary"
        @click="login">
          로그인
      </v-btn>
    </v-col>
    </v-card-text>
    </v-card-title>

    <v-row align = 'center'
    justify= "space-around"
    no-gutters>

    <div>
      <v-breadcrumbs>
        <!-- <a href="find_id">아이디 찾기</a>
        <v-col>/</v-col>
        <a href="find_pw">비밀번호 찾기</a>
        <v-col>/</v-col> -->
        <a href="Join">회원가입</a>
      </v-breadcrumbs>
    </div>
    </v-row>
    </v-card>
    </v-col>
  </v-container>
    <div class="text-center">
      <v-dialog
        v-model="dialog"
        width="500"
      >
        <v-card>
          <v-card-title class="text-h5 grey lighten-2">
            <v-icon>mdi-alert</v-icon> 로그인 정보를 확인해주세요.
          </v-card-title>
  
          <v-card-text>
            유효하지 않은 아이디 또는 비밀번호입니다.
          </v-card-text>
  
          <v-divider></v-divider>
  
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="primary"
              text
              @click="dialog = !dialog"
            >
              확인
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
  </div>
</template>
<script>
import axios from '../axios'

export default {
  data() {
    return {
      username: "",
      password: "",
      dialog: false,
    }
  },
  methods: {
    login() {
      axios.post('Account/login', {
        username: this.username,
        password: this.password,
      })
      .then(res => this.afterLogin(res.data))
      .catch(() => this.dialog = true)
    },
    afterLogin(result) {
      localStorage.setItem('username', result.username)
      localStorage.setItem('role', result.role)
      localStorage.setItem('accessToken', result.accessToken)
      localStorage.setItem('refreshToken', result.refreshToken)
      this.$router.push({ path: '/' })
    }
  }
}
</script>
<style lang="">

</style>
