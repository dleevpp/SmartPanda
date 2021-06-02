<template >
  <v-container
  fluid
  outlined>
    <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                      <th>아이디</th>
                      <th>비밀번호</th>
                      <th>주소</th>
                      <th>상세주소</th>

                      <th>삭제</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr
                      v-for="item in desserts"
                      :key="item.name"
                    >
                      <td>{{ item.id }}</td>
                      <td>{{ item.pw }}</td>
                      <td>수량</td>
                      <td>가격</td>
                      <td><v-btn>삭제</v-btn></td>
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
            id: 'id1',
            pw: '2021-04-18',
            writer: 'User1'
          },
          {
            id: 'Ice cream sandwich',
            pw: 237,
          },
          {
            id: 'Eclair',
            pw: 262,
          },
          {
            id: 'Cupcake',
            pw: 305,
          },
          {
            id: 'Gingerbread',
            pw: 356,
          },
          {
            id: 'Jelly bean',
            pw: 375,
          },
          {
            id: 'Lollipop',
            pw: 392,
          },
          {
            id: 'Honeycomb',
            pw: 408,
          },
          {
            id: 'Donut',
            pw: 452,
          },
          {
            id: 'KitKat',
            pw: 518,
          },
        ],
      }
    },
}
</script>
<style lang="">

</style>
