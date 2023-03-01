const {
  time,
  loadFixture,
} = require("@nomicfoundation/hardhat-network-helpers");
const { anyValue } = require("@nomicfoundation/hardhat-chai-matchers/withArgs");
const { expect } = require("chai");
const { ethers } = require("hardhat");

describe("BankAccount", function () {
  // We define a fixture to reuse the same setup in every test.
  // We use loadFixture to run this setup once, snapshot that state,
  // and reset Hardhat Network to that snapshot in every test.
  async function deployBankAccount() {
    
    // const ONE_YEAR_IN_SECS = 365 * 24 * 60 * 60;
    // const ONE_GWEI = 1_000_000_000;

    // const lockedAmount = ONE_GWEI;
    // const unlockTime = (await time.latest()) + ONE_YEAR_IN_SECS;

    // Contracts are deployed using the first signer/account by default
    const [addr0, addr1, addr2, addr3, addr4] = await ethers.getSigners();

    const BankAccount = await ethers.getContractFactory("BankAccount");
    const bankAccount = await BankAccount.deploy();

    return { bankAccount, addr0, addr1, addr2, addr3, addr4};
  }

  describe("Deployment", () => {
    it("Should deploy without error", async () => {
      await loadFixture(deployBankAccount);
    });
  });

  describe("Creating an account", () => {
    it("should allow creating a single user account", async () => {
      const { bankAccount, addr0 } = await loadFixture(deployBankAccount);
      await bankAccount.connect(addr0).createAccount([]);
      const accounts = await bankAccount.connect(addr0).getAccounts();
      expect(accounts.length).to.equal(1);
    });
    it("should allow creating a double user account", async () => {
      const { bankAccount, addr0, addr1 } = await loadFixture(
        deployBankAccount
      );
      await bankAccount.connect(addr0).createAccount([addr1.address]);

      const accounts1 = await bankAccount.connect(addr0).getAccounts();
      expect(accounts1.length).to.equal(1);

      const accounts2 = await bankAccount.connect(addr1).getAccounts();
      expect(accounts2.length).to.equal(1);
    });
    it("should allow creating a triple user account", async () => {
      const { bankAccount, addr0, addr1, addr2 } = await loadFixture(
        deployBankAccount
      );
      await bankAccount
        .connect(addr0)
        .createAccount([addr1.address, addr2.address]);

      const accounts1 = await bankAccount.connect(addr0).getAccounts();
      expect(accounts1.length).to.equal(1);

      const accounts2 = await bankAccount.connect(addr1).getAccounts();
      expect(accounts2.length).to.equal(1);

      const accounts3 = await bankAccount.connect(addr2).getAccounts();
      expect(accounts3.length).to.equal(1);
    });
    it("should allow creating a quad user account", async () => {
      const { bankAccount, addr0, addr1, addr2, addr3 } = await loadFixture(
        deployBankAccount
      );
      await bankAccount
        .connect(addr0)
        .createAccount([addr1.address, addr2.address, addr3.address]);

      const accounts1 = await bankAccount.connect(addr0).getAccounts();
      expect(accounts1.length).to.equal(1);

      const accounts2 = await bankAccount.connect(addr1).getAccounts();
      expect(accounts2.length).to.equal(1);

      const accounts3 = await bankAccount.connect(addr2).getAccounts();
      expect(accounts3.length).to.equal(1);

      const accounts4 = await bankAccount.connect(addr3).getAccounts();
      expect(accounts4.length).to.equal(1);
    });
    it("should not allow creating an account with duplicate owners", async () => {
      const { bankAccount, addr0 } = await loadFixture(deployBankAccount);
      await expect(bankAccount.connect(addr0).createAccount([addr0.address])).to
        .be.reverted;
    });

    it("should not allow creating an account with 5 owners", async () => {
      const { bankAccount, addr0, addr1, addr2, addr3, addr4 } =
        await loadFixture(deployBankAccount);
      await expect(
        bankAccount
          .connect(addr0)
          .createAccount([
            addr0.address,
            addr1.address,
            addr2.address,
            addr3.address,
            addr4.address,
          ])
      ).to.be.reverted;
    });
    it("should not allow creating an account with 5 owners", async () => {
      const { bankAccount, addr0 } = await loadFixture(deployBankAccount);

      for (let idx = 0; idx < 3; idx++) {
        await bankAccount.connect(addr0).createAccount([]);
      }

      await expect(bankAccount.connect(addr0).createAccount([])).to.be.reverted;
    });
  });
  describe("Despositing", () => {
    it("should allow deposit from account owner", async () => {
      const { bankAccount, addr0 } = await deployBankAccountWithAccounts(1);
      await expect(
        bankAccount.connect(addr0).deposit(0, { value: "100" })
      ).to.changeEtherBalances([bankAccount, addr0], ["100", "-100"]);
    });

    it("should NOT allow deposit from non-account owner", async () => {
      const { bankAccount, addr1 } = await deployBankAccountWithAccounts(1);
      await expect(bankAccount.connect(addr1).deposit(0, { value: "100" })).to
        .be.reverted;
    });
  });
  describe("Withdraw", () => {
    describe("Request a withdraw", () => {
      it("account owner can request withdraw", async () => {
        const { bankAccount, addr0 } = await deployBankAccountWithAccounts(
          1,
          100
        );
        await bankAccount.connect(addr0).requestWithdrawl(0, 100);
      });

      it("account owner can not request withdraw with invalid amount", async () => {
        const { bankAccount, addr0 } = await deployBankAccountWithAccounts(
          1,
          100
        );
        await expect(bankAccount.connect(addr0).requestWithdrawl(0, 101)).to.be
          .reverted;
      });

      it("non-account owner cannot request withdraw", async () => {
        const { bankAccount, addr1 } = await deployBankAccountWithAccounts(
          1,
          100
        );
        await expect(bankAccount.connect(addr1).requestWithdrawl(0, 90)).to.be
          .reverted;
      });

      it("non-account owner cannot request withdraw", async () => {
        const { bankAccount, addr0 } = await deployBankAccountWithAccounts(
          1,
          100
        );
        await bankAccount.connect(addr0).requestWithdrawl(0, 90);
        await bankAccount.connect(addr0).requestWithdrawl(0, 10);
      });
    });
    describe("Approve a withdraw", () => {
      it("should allow account owner to approve withdraw", async () => {
        const { bankAccount, addr1 } = await deployBankAccountWithAccounts(
          2,
          100,
          [100]
        );
        await bankAccount.connect(addr1).approveWithdrawl(0, 0);
        expect(await bankAccount.getApprovals(0, 0)).to.equal(1);
      });
      it("should not allow non-account owner to approve withdraw", async () => {
        const { bankAccount, addr2 } = await deployBankAccountWithAccounts(
          2,
          100,
          [100]
        );
        await expect(bankAccount.connect(addr2).approveWithdrawl(0, 0)).to.be
          .reverted;
      });
      it("should not allow owner to approve withdrawl multiple times", async () => {
        const { bankAccount, addr1 } = await deployBankAccountWithAccounts(
          2,
          100,
          [100]
        );
        bankAccount.connect(addr1).approveWithdrawl(0, 0);
        await expect(bankAccount.connect(addr1).approveWithdrawl(0, 0)).to.be
          .reverted;
      });
      it("should not allow creator of request to approve request", async () => {
        const { bankAccount, addr0 } = await deployBankAccountWithAccounts(
          2,
          100,
          [100]
        );
        await expect(bankAccount.connect(addr0).approveWithdrawl(0, 0)).to.be
          .reverted;
      });
    });
  
});
