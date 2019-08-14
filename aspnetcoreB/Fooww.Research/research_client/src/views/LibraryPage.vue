
<template>
    <div class="middle">
      <div v-if="loginStatus">
        <book-list></book-list>
      </div>
      <div class="no-auth" v-else>
        <LogoutPage></LogoutPage>
      </div>
      <!--<a-menu class="pary-menu"-->
        <!--@click="handleClick"-->
        <!--v-model="current"-->
        <!--mode="horizontal"-->
      <!--&gt;-->
        <!--<a-menu-item key="Activity">-->
          <!--<a-icon type="menu-unfold" />藏云经阁-->
        <!--</a-menu-item>-->
        <!--<a-menu-item key="Fund" >-->
          <!--<a-icon type="interation" />百家讲坛-->
        <!--</a-menu-item>-->
      <!--</a-menu>-->
      <!--<div style="min-height: 500px">-->
        <!--<router-view></router-view>-->
      <!--</div>-->
    </div>

</template>

<script>

    import BookList from "@/components/Libraries/BookList";
    import LogoutPage from "@/views/Account/LogoutPage";
    export default {
      name: "PartyPage",
      components:{ BookList,LogoutPage},
      data () {
        return {
          current: ['activity'],
        }
      },
      computed:{
        loginStatus() {
          return this.$store.state.userInfo.loginStatus;
        }
      },
      methods: {
        handleClick (e) {
          console.log('click', e)
          console.log('click', e.key)
          this.$router.push({name:e.key})
        },
        permissionInit(){

        }

      },
      created() {
        console.log("Library Created ",this.loginStatus);
        if (!this.$store.state.userInfo.loginStatus) {
          return;
        }
        this.permissionInit();
      },
    }
</script>

<style scoped>
.party{
 min-height: 700px;
  max-width: 1280px;
  margin:0 auto;
}
  .pary-menu
  {
    max-width: 1280px;
    margin:0 auto;
    display: flex;
    background: none;
  }
.no-auth {
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>


