Feature: GetUserProfile
	In order to 顯示線上操作者的資訊
	As a 線上操作者
	I want to 取得操作者的資訊

Scenario: 無操作者序號取得登入資訊
    Given 無操作者序號
    When 取得登入資訊
    Then 回傳狀態為 "BadRequest"

Scenario: 以空白操作者序號取得登入資訊
    Given 操作者序號為空白
    When 取得登入資訊
    Then 回傳狀態為 "BadRequest"

Scenario: 以操作者序號 2733 取得登入資訊
    Given 操作者序號為 2733
	When 取得登入資訊
    Then 回傳成功狀態
    And 回傳操作者序號為 2733
    And 回傳操作帳號為 "jacktsai"
    And 回傳操作者的子站為 "1,2,3,4"
    And 回傳操作者中文姓名為 "Jack Tsai"
    And 回傳操作者部門為 "研發"
    And 回傳操作者等級為 0
    And 回傳操作者首頁為 "/privilege/homepages/erp.asp"
    And 回傳操作者分機為 "3628"
    And 回傳操作者Backyard ID 為 "jacktsai"
    And 回傳細部權限-SELECT為 False
    And 回傳細部權限-INSERT為 True
    And 回傳細部權限-UPDATE為 False
    And 回傳細部權限-DELETE為 True
    And 回傳細部權限-特殊權限為 False
    
    | userId | name       |
    | 2733   | "jacktsai" |

Scenario: 以操作者序號 2121 取得登入資訊
	When 以操作者序號 2121 取得登入資訊
    Then 回傳成功狀態
    And 回傳操作者序號為 2121
    And 回傳操作帳號為 "kevincheng"
    And 回傳操作者的子站為 ""
    And 回傳操作者中文姓名為 "鄭凱文"
    And 回傳操作者部門為 "研發"
    And 回傳操作者等級為 0
    And 回傳操作者首頁為 "/privilege/homepages/ERP.asp"
    And 回傳操作者分機為 "151"
    And 回傳操作者Backyard ID 為 "kevin113"
    And 回傳細部權限-SELECT為 False
    And 回傳細部權限-INSERT為 True
    And 回傳細部權限-UPDATE為 False
    And 回傳細部權限-DELETE為 True
    And 回傳細部權限-特殊權限為 False
