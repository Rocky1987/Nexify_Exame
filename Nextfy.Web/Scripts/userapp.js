var app = new Vue({
    el: '#userapp',
    data: {
        message: 'Hello Vue!',
        user: {
            userList: [],
            isAdd: false,
            userData: {
                Name: '',
                DateOfBirth: '',
                Salary: 0,
                Address: ''
            },
        }
    },
    methods: {
        restUserData: function () {
            this.user.userData = {
                Name: '',
                DateOfBirth: '',
                Salary: 0,
                Address: '',
            };
            document.getElementById('datepicker').value = '';
        },       
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
        },
        insertUserData: function () {
            console.log(this.user.userData);
            if (!this.user.isAdd) {
                alert("請點選新紀錄新增使用者");
                return;
            }
            let self = this;
            let isConfirm = confirm('確認新增使用者??');
            if (isConfirm) {
                showBlockUI();

                axios.post('../WebApi/insertUserData', this.user.userData)
                    .then((res) => {
                        let resp = res.data
                        if (resp.status === 1 && resp.Data === null) {
                            alert(resp.errorMessage);
                        }
                        else if (resp.status === 1) {
                            self.user.userList = resp.Data;
                            self.user.isAdd = false;
                            self.restUserData();
                            alert("使用者新增成功");
                        } else {
                            alert("使用者新增失敗");
                            console.log(resp.errorMessage)
                            self.user.isAdd = false;
                            self.restUserData();
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
    },
    mounted: function () {
      
    }
});