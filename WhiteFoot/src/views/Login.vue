<template >
<v-container fluid>
<v-col cols="20">
  <v-card
  max-width="800"
  justify= "space-around">
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

    <v-row align = 'center'
    justify= "space-around"
    no-gutters>

    <div>
      <v-breadcrumbs>
        <a href="find_id">아이디 찾기</a>
        <v-col>/</v-col>
        <a href="find_pw">비밀번호 찾기</a>
        <v-col>/</v-col>
        <a href="Join">회원가입</a>
      </v-breadcrumbs>
    </div>
    </v-row>
    </v-card>
    </v-col>
  </v-container>
</template>
<script>
export default {

}
</script>
<style lang="">

</style>
