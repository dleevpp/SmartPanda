<template>
  <v-simple-table dense height="300px">
    <template v-slot:default>
      <thead>
        <th>
          <tr>
            <td colspan="20" class="text-center">장바구니</td>
          </tr>
        </th>
        <tr>
          <td colspan="20">
            <v-divider></v-divider>
          </td>
        </tr>
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
        <td colspan="20"><v-divider></v-divider></td>
      </thead>
      <tbody>
        <li v-if="item in in_cart">
          <tr
            v-for="item in in_cart"
            :key="item.name"
          >
            <td>{{ item.name }}</td>
            <td>{{ item.img }}</td>
            <td>{{item.price}}</td>
            <td>{{item.number}}</td>
          </tr>
        </li>
        <tr>
          <td colspan='20' class="text-center">비어있습니다.</td>
          <!--비었을때만 비었습니다. 나와야함.-->
        </tr>
      </tbody>
      <td colspan="20">
        <v-divider></v-divider>
      </td>
      <tr>
      <td class="text-left">
        <tr
        v-for="item in in_cart"
        :key="item.name"
        ></tr>
        <tr>
          <td>상품 가격 : </td>
          <td>price</td>
        </tr>
        <tr>
          <td>배송비 : </td>
          <td>price</td>
        </tr>
        <tr>
          <td>합계 : </td>
          <td>price</td>
        </tr>
      </td>
      </tr>
    </template>
  </v-simple-table>

</template>


<script>
export default {
  data () {
      return {
        in_cart: [
            {
            name: 'Cupcake',
            img: 305,
            price: 3.7,
            number: 67,
          },
          {
            name: 'Gingerbread',
            img: 305,
            price: 3.7,
            number: 67,
          },


        ],
      }
    },
}
</script>
<style lang="">

</style>
