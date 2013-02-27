Feature: GetUserPrivileges
	In order to 權限控管
	As a 線上操作者
	I want to 確認使用者權限
    
Scenario: 以無操作者序號確認權限
    Given 無操作者序號
    And 無目標網址
    When 確認操作者權限
    Then 回傳狀態為 "BadRequest"

Scenario: 以空白操作者序號確認權限
    Given 操作者序號為空白
    And 目標網址為空白
    When 確認操作者權限
    Then 回傳狀態為 "BadRequest"

Scenario: 以操作者序號 2733 確認有無 /privileges/default.aspx 的權限
	When 以使用者編號 2733 取得權限清單
	Then 回傳使用者編號為 2733
