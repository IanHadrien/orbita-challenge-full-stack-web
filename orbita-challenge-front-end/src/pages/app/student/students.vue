<template>
  <div class="px-6 pt-4">
    <div class="border flex items-center justify-between space-x-16">
      <v-text-field
        label="Prepend inner"
        prepend-inner-icon="mdi-map-marker"
        variant="outlined"
        rounded="lg"
        density="compact"
      />

      <RegisterStudent />
    </div>
    
    <!-- Table -->
    <v-data-table
      :headers="headers"
      :items="students"
      :sort-by="[{ key: 'id', order: 'asc' }]"
      :loading="loading"
    >
      <template #item.actions="{ item }">
        <UpdateStudent :student="item" />

        <DeleteStudent :student="item" />
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
          console.log("Studantes:", students)
        } catch (error) {
          this.toast.error('Falha ao carregar estudantes:')
        } finally {
          this.loading = false
        }
      }
    },
  }
</script>