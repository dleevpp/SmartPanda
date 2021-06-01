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

              cols="12"
              md="4"
            >
               <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                      <th>주문 일자</th>
                      <th>이미지</th>
                      <th>수량</th>
                      <th>가격</th>
                      <th>주문처리상태</th>
                      <th>취소/교환/반품</th>
                    </tr>
                  </thead>
                  <tbody>

                    <tr
                      v-for="item in desserts"
                      :key="item.name"
                    >
                      <td>{{ item.name }}</td>
                      <td>{{ item.calories }}</td>
                    </tr>
                  </tbody>
                </template>
              </v-simple-table>
            </v-col>
          </v-row>
        </v-container>
      </v-tab-item>
  </v-tabs>

  </v-container>
</template>
<script>
export default {
    data () {
      return {
        desserts: [
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
