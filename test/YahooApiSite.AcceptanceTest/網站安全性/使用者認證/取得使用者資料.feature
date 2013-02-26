Feature: 取得操作者的登入資訊
	In order to 顯示線上操作者的資料
	As a 線上使用者
	I want to 取得操作者的資料

@HttpClient
Scenario: 無操作者序號取得登入資訊
    When 無操作者序號取得登入資訊
    Then 回傳狀態為 "BadRequest"

@HttpClient
Scenario: 以 null 操作者序號取得登入資訊
    When 以 null 操作者序號取得登入資訊
    Then 回傳狀態為 "BadRequest"

@HttpClient
Scenario: 以操作者序號 2733 取得登入資訊
	When 以操作者序號 2733 取得登入資訊
    Then 回傳成功狀態
    And 回傳操作者序號為 2733
    And 回傳操作帳號為 "jacktsai"
    And 回傳操作者的子站為 "1,2,3,4"
    And 回傳操作者中文姓名為 "蔡逸華"
    And 回傳操作者部門為 "工程部"
    And 回傳操作者等級為 1
    And 回傳操作者首頁為 "http://"
    And 回傳操作者分機為 "124567"
    And 回傳操作者Backyard ID 為 "jacktsai"
    And 回傳細部權限-SELECT為 False
    And 回傳細部權限-INSERT為 True
    And 回傳細部權限-UPDATE為 False
    And 回傳細部權限-DELETE為 True
    And 回傳細部權限-特殊權限為 False
