import axios from "axios";
import {
  loginStart,
  loginSuccess,
  loginFail,
  registerStart,
  registerSuccess,
  registerFail,
} from "../Redux/Account";
import { decodeAndSaveUserInfo } from "../Common/function";
import toast from "react-hot-toast";

export function loginUser(user, dispatch, navigate) {
  return new Promise((resolve, reject) => {
    dispatch(loginStart());
    axios
      .post(process.env.REACT_APP_API_LOGIN, user)
      .then((response) => {
        const data = response.data;
        if (data.flag === false) {
          toast.error("Xảy ra lỗi không thể đăng nhập");
          reject(new Error("Login failed"));
        }
        const userInfo = decodeAndSaveUserInfo(data.token);
        dispatch(loginSuccess(userInfo));
        const recentRegister = localStorage.getItem("recentRegister");
        if (recentRegister) {
          navigate("/");
        } else {
          window.history.go(-1);
        }
        toast.success("Đăng nhập thành công");
        resolve(userInfo);
      })
      .catch((error) => {
        if (error.response && error.response.status === 401) {
          // Kiểm tra nếu lỗi là mã trạng thái 401 (Unauthorized)
          toast.error("Thông tin đăng nhập không chính xác.");
        } else {
          toast.error("Đã xảy ra lỗi khi đăng nhập:", error);
        }
        dispatch(loginFail());
        reject(error);
      });
  });
}

export function registerUser(user, dispatch, navigate) {
  return new Promise((resolve, reject) => {
    dispatch(registerStart());
    try {
      axios.post(process.env.REACT_APP_API_REGISTER, user).then((response) => {
        const data = response.data;
        if (data.flag === false) {
          toast.error("Xảy ra lỗi không thể đăng ký: " + data.message);
          return;
        }
        dispatch(registerSuccess());
        toast.success("Đăng ký tài khoản thành công");
        navigate("/login");
      });
    } catch (error) {
      dispatch(registerFail());
    }
  });
}
