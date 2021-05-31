<template >
<v-container fluid>

  <v-card
  max-width="800">
    <v-card-title>
      <v-card-text>
    <v-form>
          <v-text-field
            label="아이디"
            required
          ></v-text-field>
    </v-form>
    <v-form>
          <v-text-field
            label="비밀번호"
            required
          ></v-text-field>
    </v-form>
    <v-btn
    class="ar-4"
    type="submit"
    color="primary">로그인</v-btn>
    </v-card-text>
    </v-card-title>
  </v-card>
    <v-row align = 'center'
    justify="center"
    no-gutters>
    <v-col>아이디 찾기</v-col>
    <v-col>비밀번호 찾기</v-col>
    <v-col><a href="Join">회원가입</a></v-col>
    </v-row>

  </v-container>
</template>
<script>
export default {

}
</script>
<style lang="">

</style>
