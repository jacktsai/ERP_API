Feature: UpdateProductSize
	In order to 與 ERP 資料同步
	As a 進倉作業操作人員
	I want to 更新商品材積

Scenario: 以無商品編號更新商品材積
	Given 無商品編號
	When 更新商品材積
    Then HTTP回傳狀態為 'BadRequest'

Scenario: 以空白商品編號更新商品材積
    Given 空白商品編號
    When 更新商品材積
    Then HTTP回傳狀態為 'BadRequest'

Scenario: 更新商品編號12002的材積
    Given 商品編號為 12002
    And 長度為 10.1
    And 寬度為 10.2
    And 高度為 10.3
    And 重量為 99
    And 進倉單號為 'ErpApiTest'
    When 更新商品材積
    Then HTTP回傳成功狀態
    And 更新後的商品編號為 12002
    And 更新後的長度為 10.1
    And 更新後的寬度為 10.2
    And 更新後的高度為 10.3
    And 更新後的重量為 99
    And 更新後的更新人員為 'ErpApiTest'