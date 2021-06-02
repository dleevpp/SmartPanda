<template lang="">
  <v-container
  fluname
  outlined>
    <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                      <th>상품명</th>
                      <th>이미지</th>
                      <th>평점</th>
                      <th>삭제</th>
                      <th>수정</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr
                      v-for="item in desserts"
                      :key="item.name"
                    >
                      <td>{{ item.name }}</td>
                      <td><v-img
                      :max-width="80"
                      :src="item.im_g"
                      />
                      <p>{{item.im_g}}</p>
                      </td>
                      <td>{{item.score}}/5.0</td>
                      <td><v-btn type="submit">삭제</v-btn></td>
                      <td><v-btn v-bind:to="item.source">수정</v-btn></td>
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
        desserts: [
          {
            name: 'naem1',
            score: '4.5',
            source: 'product-submit',
            im_g: require("@/assets/logo.png")
          },
          {
            name: 'Ice cream sandwich',
            im_g: 237,
          },
          {
            name: 'Eclair',
            im_g: 262,
          },
          {
            name: 'Cupcake',
            im_g: 305,
          },
          {
            name: 'Gingerbread',
            im_g: 356,
          },
          {
            name: 'Jelly bean',
            im_g: 375,
          },
          {
            name: 'Lollipop',
            im_g: 392,
          },
          {
            name: 'Honeycomb',
            im_g: 408,
          },
          {
            name: 'Donut',
            im_g: 452,
          },
          {
            name: 'KitKat',
            im_g: 518,
          },
        ],
      }
    },
}
</script>
<style lang="">

</style>
