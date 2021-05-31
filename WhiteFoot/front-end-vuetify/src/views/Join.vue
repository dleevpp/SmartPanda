<template>
   <v-form v-model="valid">
    <v-container>

      <v-row>
          <v-text-field
            :counter="10"
            label="아이디"
            required
          ></v-text-field>
      </v-row>
        <v-row>
          <v-text-field
            label="비밀번호"
            required
          ></v-text-field>
        </v-row>
        <v-row>
          <v-text-field
            label="비밀번호 확인"
            required
          ></v-text-field>
        </v-row>
        <v-row>
          <v-text-field
            label="주소"
            required
          ></v-text-field>
        </v-row>
        <v-row>
          <v-text-field
            label="상세주소"
            required
          ></v-text-field>
        </v-row>
    </v-container>
    <v-row align="center">
      <v-col cols='auto'></v-col>
      <v-col cols='auto'></v-col>
      <v-col>   *본인은 만 14세 이상이며, 개인정보 처리방침 및 이용약관을 확인하였으며 이에 동의합니다.
      </v-col>
    </v-row>
     <v-btn block
  color="primary">
    동의하고 회원가입
  </v-btn>
  </v-form>

</template>
<script>
export default {

}
</script>
<style lang="">

</style>
