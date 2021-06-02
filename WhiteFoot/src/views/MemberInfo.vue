<template >
  <v-container
    fluid
    outlined>
    <v-row
      justify= "space-around">
        <th>회원 관리</th>
    </v-row>
    <v-simple-table>
      <template v-slot:default>
        <thead>
          <tr>
            <th>아이디</th>
            <th>계정 유형</th>
            <th>주소</th>
            <th>상세주소</th>
            <th>삭제</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="user in users"
            :key="user.id"
          >
            <td>{{ user.username }}</td>
            <td>{{ getUserRoleText(user.role.name) }}</td>
            <td>{{ user.address1 }}</td>
            <td>{{ user.address2 }}</td>
            <td><v-btn @click="deleteUser(user.id)">삭제</v-btn></td>
          </tr>
        </tbody>
      </template>
    </v-simple-table>
  </v-container>
</template>
<script>
import axios from '../axios'
import auth from '../auth'

export default {
 data () {
    return {
      users: [],
    }
  },
  created() {
    this.getUsers();
  },
  methods: {
    getUsers() {
      axios.get('User/all', auth.axiosConfig)
        .then(res => {
          console.log(res)
          this.users = res.data
        })
        .catch(e => console.log(e))
    },
    getUserRoleText(role) {
      if (role === "Admin")     return '관리자'
      if (role === "Seller")    return '사업자 회원'
      if (role === "Customer")  return '개인 회원'
      return ''
    },
    deleteUser(id) {
      axios.delete(`User/${id}`, auth.axiosConfig)
        .catch(e => console.log(e))
    }
  }
}
</script>