<template lang="">

   <v-card
    class="mx-auto text-center"
    color="green"
    dark
    max-width="600"
  >
    <v-card-text>
      <v-sheet color="rgba(0, 0, 0, .12)">
        <v-sparkline
          :value="value"
          color="rgba(255, 255, 255, .7)"
          height="100"
          padding="24"
          stroke-linecap="round"
          smooth
        >
          <template v-slot:label="item">
            ${{ item.value }}
          </template>
        </v-sparkline>
      </v-sheet>
    </v-card-text>
    <v-card-text>
      <div class="text-h4 font-weight-thin">
        Sales Last 24h
      </div>
    </v-card-text>
    <v-divider></v-divider>
    <v-card-actions class="justify-center">
    </v-card-actions>

    <v-bottom-navigation
    color="primary"
  >
    <v-btn to='product-control'>
      <span>상품관리</span>

      <v-icon>mdi-archive</v-icon>
    </v-btn>

    <v-btn to='member_info'>
      <span>회원관리</span>

      <v-icon>mdi-face-agent</v-icon>
    </v-btn>

    <v-btn to='product-submit'>
      <span>상품등록</span>

      <v-icon>mdi-reproduction</v-icon>
    </v-btn>
  </v-bottom-navigation>
  </v-card>

</template>

<script>
 export default {
    data: () => ({
      value: [
        423,
        446,
        675,
        510,
        590,
        610,
        760,
      ],
    }),
  }
</script>
<style lang="">

</style>
