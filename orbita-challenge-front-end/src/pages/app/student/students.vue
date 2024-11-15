<template>
  <div class="px-6 pt-4">
    <div class="sm:flex items-center justify-between space-y-2 sm:space-y-0 sm:space-x-16 mb-2">
      <div class="w-full flex items-center space-x-2">
        <v-text-field
          label="Pesquisar por nome, cpf e registro"
          variant="outlined"
          rounded="lg"
          density="compact"
          hide-details="auto"
          v-model="search"
          data-testid="search-input"
        />

        <v-btn 
          density="comfortable" 
          rounded
          icon="mdi-magnify" 
          color="#2D2C2C"
          @click="searchQuery"
        />
      </div>

      <RegisterStudent @register-success="getStudents" />
    </div>
    
    <!-- Table -->
    <v-data-table
      :headers="headers"
      :items="students"
      :sort-by="[{ key: 'id', order: 'asc' }]"
      :loading="loading"
    >
      <template #item.actions="{ item }">
        <UpdateStudent :student="item" @update-success="getStudents" />

        <DeleteStudent :student="item" @delete-success="getStudents" />
      </template>
    </v-data-table>
  </div>
</template>

<script lang="ts">
  import RegisterStudent from './register-student.vue'
  import UpdateStudent from './update-student.vue'
  import DeleteStudent from './delete-student.vue'
  import { getStudentsApi } from '@/api/student/get-students'
  import { Student } from "@/_types/student"
  import { useToast } from 'vue-toastification'

  export default {
    name: "Students",

    setup() {
      const toast = useToast()
      return { toast }
    },

    data: () => ({
      headers: [
        { title: 'REGISTRO ACADÊMICO', align: 'start' as const, sortable: false, key: 'ra'},
        { title: 'NOME', align: 'start' as const, sortable: true, key: 'name' },
        { title: 'CPF', align: 'start' as const, sortable: true, key: 'cpf' },
        { title: '', key: 'actions', align: 'center' as const, sortable: false },
      ],

      students: Array<Student>(),
      loading: false,
      search: ""
    }),

    components: {
      RegisterStudent,
      UpdateStudent,
      DeleteStudent
    },

    created () {
      this.getStudents()
    },

    methods: {
      async getStudents() {
        this.loading = true
        try {
          const students = await getStudentsApi()
          this.students = students
        } catch (e) {
          this.toast.error('Falha ao carregar estudantes.')
        } finally {
          this.loading = false
        }
      },

      async searchQuery() {
        this.loading = true
        try {
          const students = await getStudentsApi(this.search)
          this.students = students
        } catch (e) {
          this.toast.error('Falha ao pesquisar estudantes.')
        } finally {
          this.loading = false
        }
      }
    },
  }
</script>