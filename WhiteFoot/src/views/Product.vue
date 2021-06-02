<template>
  <v-container>
    <v-row>
      <v-col>
        <v-img lazy-src="https://picsum.photos/id/11/10/6"
                max-height="150"
                max-width="250"
                src="https://picsum.photos/id/11/500/300"
                >
        </v-img>
      </v-col>
      <v-col>
        <v-row>
        <v-col>
          상품이름
        </v-col>
        <v-col>
          이름이다
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          가격
        </v-col>
        <v-col>
          가격이다
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          제조사
        </v-col>
        <v-col>
          제조사다
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          제조국가
        </v-col>
        <v-col>
          제조국가다
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          상품 분류
        </v-col>
        <v-col>
          상품 분류다
        </v-col>
      </v-row>
      <v-divider/>
      <v-row>
        <v-col>
          금액(수량) :
        </v-col>
        <v-col>
          원(개)
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-btn>구매하기</v-btn>
        </v-col>
        <v-col>
          <v-btn>장바구니 담기</v-btn>
        </v-col>
      </v-row>
      </v-col>
    </v-row>
    <v-row><v-divider></v-divider></v-row>
    <v-row><v-spacer></v-spacer></v-row>
    <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                      <th>아이디</th>
                      <th>리뷰</th>
                      <th>별점</th>
                      <th>상세보기</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr
                      v-for="item in desserts"
                      :key="item.id"
                    >
                      <td>{{ item.id }}</td>
                      <td>{{ item.rv }}</td>
                      <td>{{item.score}}/5.0</td>
                      <td><a v-bind:href="item.review">상세보기</a></td>
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
            id: 'Frozen Yogurt',
            rv: 159,
            score:'4.5',
            review: 'review3'
          },
          {
            id: 'Ice cream sandwich',
            rv: 237,
          },
          {
            id: 'Eclair',
            rv: 262,
          },
          {
            id: 'Cupcake',
            rv: 305,
          },
          {
            id: 'Gingerbread',
            rv: 356,
          },
          {
            id: 'Jelly bean',
            rv: 375,
          },
          {
            id: 'Lollipop',
            rv: 392,
          },
          {
            id: 'Honeycomb',
            rv: 408,
          },
          {
            id: 'Donut',
            rv: 452,
          },
          {
            id: 'KitKat',
            rv: 518,
          },
        ],
      }
    },
  }

</script>
<style lang="">

</style>