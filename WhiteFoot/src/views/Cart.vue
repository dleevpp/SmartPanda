<template>
  <v-simple-table dense>
    <template v-slot:default>
      <thead>
        <th>

        </th>
        <tr>
          <td class="text-left">
            상품명
          </td>
          <td class="text-left">
            이미지
          </td>
          <td class="text-left">
            가격
          </td>
          <td class="text-left">
            수량
          </td>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in desserts"
          :key="item.name"
        >
          <td>{{ item.name }}</td>
          <td>{{ item.img }}</td>
          <td>{{item.price}}</td>
          <td>{{item.number}}</td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>
<script>
export default {
  data () {
      return {
        desserts: [
          {
            name: 'Frozen Yogurt',
            img: 159,
            price: 100,
            number: 1
          },
          {
            name: 'Ice cream sandwich',
            calories: 237,
            price: 200,
            number: 2
          },
          {
            name: 'Eclair',
            calories: 262,
            price: 300,
            number: 10
          },
        ],
      }
    },
}
</script>
<style lang="">

</style>
