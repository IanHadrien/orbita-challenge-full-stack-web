<template>
  <v-dialog
    v-model="dialog"
    max-width="500px"
  >
    <template v-slot:activator="{ props }">
      <v-btn 
        density="compact" 
        rounded
        icon="mdi-delete-outline" 
        color="#CE002E"
        v-bind="props"
      />
    </template>

    <v-card>
      <v-card-title class="border-b-2">
        <span class="text-h5">Excluir Aluno</span>
      </v-card-title>

      <div class="p-2 px-4 pt-5">
        <div>
          <p>
            Tem certeza que deseja excluir o aluno
            <span class="font-medium">{{ student.name }}</span> ?
          </p>
        </div>

        <div class="flex items-center justify-end space-x-2 mt-4">
          <div>
            <v-btn
              class="text-subtitle-1 flex-grow-1 w-full sm:w-auto justify-center rounded-md font-medium shadow-sm hover:opacity-80"
              variant="flat"
              color="#CE002E"
              @click="close"
            >
              Cancelar
            </v-btn>
          </div>

          <div>
            <v-btn
              :loading="loading"
              class="text-subtitle-1 flex-grow-1 w-full sm:w-auto justify-center rounded-md font-medium shadow-sm hover:opacity-80"
              variant="flat"
              color="#2D2C2C"
              type="submit"
              @click="deleteStudent"
            >
              Confirmar
            </v-btn>
          </div>
        </div>
      </div>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
  import { Student } from '@/_types/student'
import { deleteStudentApi } from '@/api/student/delete-student';
  import { PropType } from 'vue'
  import { useToast } from 'vue-toastification'

  export default {
    name: 'DeleteStudent',

    props: {
      student: {
        type: Object as PropType<Student>,
        required: true,
      },
    },

    setup() {
      const toast = useToast();

      return { toast }
    },
    
    data() {
      return {
        dialog: false,

        studentForm: {
          id: this.student.id,
          name: this.student.name,
        },

        loading: false,
      }
    },

    methods: {
      async deleteStudent (e: MouseEvent) {
        e.preventDefault()
        this.loading = true

        try {
          await deleteStudentApi({
            id: this.studentForm.id,
          })

          this.toast.success("Aluno excluído com sucesso!")

          this.$emit("delete-success")
          this.close()
        } catch (e) {
          console.error("Erro:", e)
          this.toast.error('Falha ao excluir aluno.')
        } finally {
          this.loading = false
        }
      },

      close () {
        this.dialog = false
      },
    }
  }
</script>