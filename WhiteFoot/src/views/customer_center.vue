<template>
  <v-container>
    <v-banner>
      <th rowspan="200">고객센터</th>
    </v-banner>
    <v-simple-table>
    <template v-slot:default>
      <thead>
        <th>문의사항</th>
        <tr>
          <th class="text-left">
            제목
          </th>
          <th class="text-left">
            날짜
          </th>
          <th class="text-left">
            작성자
          </th>


        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in QA"
          :key="item.title"
        >
          <td>{{ item.title }}</td>
          <td>{{ item.date }}</td>
          <td>{{ item.writer }}</td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
  </v-container>
</template>

<script>
  export default {
    data () {
      return {
        QA: [
          {
            title: 'Frozen Yogurt',
            date: 159,
          },
          {
            title: 'Ice cream sandwich',
            date: 237,
          },
          {
            title: 'Eclair',
            date: 262,
          },
          {
            title: 'Cupcake',
            date: 305,
          },
          {
            title: 'Gingerbread',
            date: 356,
          },
          {
            title: 'Jelly bean',
            date: 375,
          },
          {
            title: 'Lollipop',
            date: 392,
          },
          {
            title: 'Honeycomb',
            date: 408,
          },
          {
            title: 'Donut',
            date: 452,
          },
          {
            title: 'KitKat',
            date: 518,
          },
        ],
      }
    },
  }
</script>
<style lang="">

</style>
