<template >

  <v-container
  fluid
  >
   <v-carousel
    cycle
    height="400"
    hide-delimiter-background
    show-arrows-on-hover
  >
    <v-carousel-item
      v-for="(slide, i) in slides"
      :key="i"
    >
      <v-sheet
        :color="colors[i]"
        height="100%"
      >
        <v-row
          class="fill-height"
          align="center"
          justify="center"
        >
          <div class="text-h2">
            {{ slide }} Slide
          </div>
        </v-row>
      </v-sheet>
    </v-carousel-item>
  </v-carousel>
<v-divider></v-divider>
  <v-row>
    <v-row></v-row>
    <v-row>
    Best Seller
    </v-row>
    <v-row justify= "space-around">
      <v-col
      v-for="count in 12"
      :key="count"
      cols="3"
      >
      <v-card
      class="pa-3"
      outlined
      >
      아이템 이미지
      <v-card>아이템은 이런거다</v-card>
      </v-card>

      </v-col>
    </v-row>
  </v-row>



  </v-container>
</template>

<script>
 export default {
    data () {
      return {
        colors: [
          'indigo',
          'warning',
          'pink darken-2',
          'red lighten-1',
          'deep-purple accent-4',
        ],
        slides: [
          'First',
          'Second',
          'Third',
          'Fourth',
          'Fifth',
        ],
      }
    },
  }
</script>
<style lang="">

</style>
