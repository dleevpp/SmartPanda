<template>
  <v-container>
    <th>주문조회</th>
    <v-tabs>
    <v-tab>주문내역조회</v-tab>
    <v-tab>취소/반품/교환 내역</v-tab>
    <v-tab>과거주문내역</v-tab>
    <v-tab-item
        v-for="n in 3"
        :key="n"
      >
        <v-container fluid>
          <v-row>
            <v-col
              v-for="i in 6"
              :key="i"
              cols="12"
              md="4"
            >
              <v-img
                :src="`https://picsum.photos/500/300?image=${i * n * 5 + 10}`"
                :lazy-src="`https://picsum.photos/10/6?image=${i * n * 5 + 10}`"
                aspect-ratio="1"
              ></v-img>
            </v-col>
          </v-row>
        </v-container>
      </v-tab-item>
  </v-tabs>

  </v-container>
</template>
<script>
export default {

}
</script>
<style lang="">

</style>
