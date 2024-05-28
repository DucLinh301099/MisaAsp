<template>
  <div class="login-page">
    <div class="login-container">
      <div class="logo-section">
        <router-link to="/">
          <img src="C:\Users\vdlinh\source\repos\Vuejs\Day3\misa-asp\src\assets\image\logo123.jpg" alt="MISA ASP Logo" class="main-logo" />
        </router-link>
        
      </div>
      <h2>Đăng nhập</h2>
      <form @submit.prevent="login">
        <div class="form-group">
          <input type="text" v-model="email" placeholder="Số điện thoại/Email" required />
        </div>
        <div class="form-group">
          <input type="password" v-model="password" placeholder="Mật khẩu" required />
          <span class="error-message">Mật khẩu không được để trống</span>
        </div>
        <button type="submit" class="login-button">Đăng nhập</button>
      </form>
      <div class="extra-links">
        <p>Bạn chưa có tài khoản? <router-link to="/register">Đăng ký</router-link></p>
        <p><router-link to="#">Quên mật khẩu?</router-link></p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'LoginComponent',
  data() {
    return {
      email: '',
      password: ''
    };
  },
  methods: {
    login() {
      // Handle login logic here
      console.log('Logging in with', this.email, this.password);
    }
  }
};
</script>

<style scoped>
.login-page {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #0A2540;
}

.login-container {
  background-color: #fff;
  padding: 40px;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  text-align: center;
  width: 400px;
}

.logo-section {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;
}

.main-logo {
  height: 60px;
}

.misa-logo {
  height: 24px;
}

h2 {
  margin-bottom: 20px;
  font-size: 24px;
  color: #333;
}

.form-group {
  margin-bottom: 20px;
}

.form-group input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.error-message {
  color: red;
  font-size: 12px;
  text-align: left;
  margin-top: 5px;
}

.login-button {
  width: 100%;
  padding: 10px;
  border: none;
  border-radius: 4px;
  background-color: #4CAF50;
  color: white;
  cursor: pointer;
  font-size: 16px;
}

.extra-links {
  margin-top: 20px;
}

.extra-links p {
  margin: 5px 0;
}

.extra-links a {
  color: #1E90FF;
  text-decoration: none;
}

.extra-links a:hover {
  text-decoration: underline;
}
</style>
