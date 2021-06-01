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
  <v-row>
    <v-divider></v-divider>
  </v-row>
  <v-row>
    <v-col></v-col>
    <v-row aria-rowspan="2">
      <v-col>Best Seller</v-col>
    </v-row>

  </v-row>
  <v-row justify= "space-around">
      <v-col
      v-for="item in BEST_SELLERS"
      :key="item.name"
      cols="3"
      >
        <v-card
        class="pa-3"
        outlined
        >
        {{item.name}}
          <v-card>{{item.calories}}</v-card>
        </v-card>
      </v-col>
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
        BEST_SELLERS: [
          {
            name: 'Frozen Yogurt',
            calories: 159,
          },
          {
            name: 'Ice cream sandwich',
            calories: 237,
          },
          {
            name: 'Eclair',
            calories: 262,
          },
          {
            name: 'Cupcake',
            calories: 305,
          },
          {
            name: 'Gingerbread',
            calories: 356,
          },
          {
            name: 'Jelly bean',
            calories: 375,
          },
          {
            name: 'Lollipop',
            calories: 392,
          },
          {
            name: 'Honeycomb',
            calories: 408,
          },
          {
            name: 'Donut',
            calories: 452,
          },
          {
            name: 'KitKat',
            calories: 518,
          },
        ],
      }
    },
  }
</script>
<style lang="">

</style>
