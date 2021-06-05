var app = new Vue({
    el: '#userapp',
    data: {
        message: 'Hello Vue!',
        user: {
            userList: [],
            isAdd: false,
        }
    },
    methods: {
        getUsertData: function () {
            let self = this;
            showBlockUI();
             axios.post('../WebApi/getUsertData')
                .then((res) => {
                    let resp = res.data
                    if (resp.status === 1) {
                        self.user.userList = resp.Data;
                    } else {
                        alert("取得資料錯誤");
                        console.log(res.errorMessage)
                    }
                    //console.log(res.data)
                    unBlockUI();
                })
                .catch(
                    (error) => {
                        unBlockUI();
                        console.error(error)
                    }
                );
        }
    },
    mounted:function() {

    }
})