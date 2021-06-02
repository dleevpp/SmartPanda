<template>
  <div>
    <v-form v-model="valid">
      <v-container>
        <v-row>
          <v-col>기본정보</v-col>
          <v-spacer/>
          <v-col>*필수입력사항</v-col>
        </v-row>
        <v-spacer/>
        <v-row>
          <v-text-field
            :counter="10"
            label="* 아이디"
            v-model="username"
            required
          />
        </v-row>
        <v-row>
          <v-text-field
            label="* 비밀번호"
            v-model="password"
            required
          />
        </v-row>
        <v-row>
          <v-text-field
            label="* 비밀번호 확인"
            v-model="passwordCheck"
            required
          />
        </v-row>
        <v-row>
          <v-text-field
            label="주소"
            v-model="address1"
            required
          />
        </v-row>
        <v-row>
          <v-text-field
            label="상세주소"
            v-model="address2"
            required
          />
        </v-row>
      </v-container>
    <v-row align="center">
      <v-col cols='auto'></v-col>
      <v-col cols='auto'></v-col>
      <v-col>   *본인은 만 14세 이상이며,<a href="privacy_inform_policy"> 개인정보 처리방침</a> 및 <a href="user_yakgwan">이용약관</a>을 확인하였으며 이에 동의합니다.
      </v-col>
    </v-row>
      <v-btn block
        @click="submit"
        color="primary">
        동의하고 회원가입
      </v-btn>
    </v-form>

    <div class="text-center">
      <v-dialog
        v-model="dialog"
        width="500"
      >
        <v-card>
          <v-card-title class="text-h5 grey lighten-2">
            회원 가입을 축하합니다.
          </v-card-title>
  
          <v-card-text>
            회원 가입이 완료되었습니다. 아래 버튼을 눌러 로그인 페이지로 이동해 로그인 해주세요.
          </v-card-text>
  
          <v-divider></v-divider>
  
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="primary"
              text
              @click="redirectToLogin"
            >
              로그인 페이지로
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
      valid: true,
      dialog: false,
      username: "",
      password: "",
      passwordCheck: "",
      address1: "",
      address2: "",
    }
  },
  methods: {
    submit() {
      if (this.password === this.passwordCheck) {
        axios.post('User', {
          Username: this.username,
          Password: this.password,
          Address1: this.address1,
          Address2: this.address2,
        })
        .then(() => this.dialog = true)
        .catch(e => console.log(e))
      }
    },
    redirectToLogin() {
      this.$router.push({ path: 'login' })
    }
  }
}
</script>
<style lang="">

</style>
