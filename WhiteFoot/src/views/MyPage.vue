<template >
  <v-container
  fluid
  >
    <v-row
    justify= "space-around">
      <v-col
      v-for="count in 12"
      :key="count"
      cols="3"
      >
      <v-card
      class="pa-3"
      outlined
      >
      마이페이지
      </v-card>
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
