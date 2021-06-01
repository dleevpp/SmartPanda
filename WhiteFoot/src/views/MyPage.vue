<template >
  <v-container
  fluid
  >
    <v-row
    justify= "space-around">
      <th>마이페이지</th>
    </v-row>
    <v-row>
      <v-card class = "mx-auto"
      min-width="800px">
        <v-card-text class="grey lighten-4">
          <v-row>
            <v-col>
              000님
            </v-col>
            <v-col>
              포인트
            </v-col>
            <v-col>
              쿠폰
            </v-col>
          </v-row>
          <v-row>
            <v-col>
            <a href="https://www.google.com">회원정보수정</a>
            </v-col>
            <v-col>
              0P
            </v-col>
            <v-col>
              1장
            </v-col>
          </v-row>
        </v-card-text>
      </v-card>

    </v-row>
    <v-row>
      <v-col><th>최근 주문 현황 (최근 6개월)</th></v-col>
    </v-row>

    <v-row>
      <v-col>숫자
        <v-row>입금 확인</v-row>
      </v-col>
      <v-col>></v-col>
      <v-col>숫자
        <v-row>배송 준비</v-row>
      </v-col>
      <v-col>></v-col>
      <v-col>숫자
        <v-row>배송중</v-row>
      </v-col>
      <v-col>></v-col>
      <v-col>숫자
        <v-row>배송완료</v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {

}
</script>
<style lang="">

</style>
